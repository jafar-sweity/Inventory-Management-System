using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using System.Data.SqlClient;

namespace Inventory_Management_System_with_DB.Repositories
{
    public class InventorySQL : IInventory
    {
        private readonly string _connectionString;

        public InventorySQL(string connectionString)
        {
            _connectionString = connectionString;
        }

        private async Task<SqlConnection> OpenConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task AddProduct(Product product)
        {
            const string query = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.QuantityInStock);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            const string query = "SELECT * FROM Products";
            var products = new List<Product>();

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var product = new Product(
                    reader["Name"].ToString(),
                    Convert.ToDecimal(reader["Price"]),
                    Convert.ToInt32(reader["Quantity"])
                );
                products.Add(product);
            }

            return products;
        }

        public async Task<int> Count()
        {
            const string query = "SELECT COUNT(*) FROM Products";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);

            return (int)await command.ExecuteScalarAsync();
        }

        public async Task<Product> SearchProductByName(string name)
        {
            const string query = "SELECT * FROM Products WHERE Name = @Name";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Product(
                    reader["Name"].ToString(),
                    Convert.ToDecimal(reader["Price"]),
                    Convert.ToInt32(reader["Quantity"])
                );
            }

            return null;
        }

        public async Task<bool> EditProductName(Product product, string newName)
        {
            const string query = "UPDATE Products SET Name = @NewName WHERE Name = @OldName";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewName", newName);
            command.Parameters.AddWithValue("@OldName", product.Name);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> EditProductPrice(Product product, decimal newPrice)
        {
            const string query = "UPDATE Products SET Price = @NewPrice WHERE Name = @Name";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewPrice", newPrice);
            command.Parameters.AddWithValue("@Name", product.Name);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> EditProductQuantity(Product product, int newQuantity)
        {
            const string query = "UPDATE Products SET Quantity = @NewQuantity WHERE Name = @Name";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewQuantity", newQuantity);
            command.Parameters.AddWithValue("@Name", product.Name);

            return await command.ExecuteNonQueryAsync() > 0;
        }

        public async Task DeleteProductByName(string name)
        {
            const string query = "DELETE FROM Products WHERE Name = @Name";

            using var connection = await OpenConnectionAsync();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);

            var rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected == 0)
            {
                throw new Exception("Product not found.");
            }

            Console.WriteLine("Product deleted successfully.");
        }
    }
}

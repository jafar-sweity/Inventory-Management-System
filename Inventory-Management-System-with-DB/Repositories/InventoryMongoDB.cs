using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using Inventory_Management_System_with_DB.DataBaseConnection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inventory_Management_System_with_DB.Repositories
{
    public class InventoryMongoDB : IInventory
    {
        private readonly IMongoCollection<BsonDocument> _productsCollection;


        public InventoryMongoDB()
        {
            var client = new MongoClient(MongoDBConnection.ConnectionString);
            var database = client.GetDatabase(MongoDBConnection.DatabaseName);
            _productsCollection = database.GetCollection<BsonDocument>("Products");
        }

        public async Task AddProduct(Product product)
        {
            var document = new BsonDocument
            {
                { "Name", product.Name },
                { "Price", product.Price },
                { "Quantity", product.QuantityInStock }
            };
            await _productsCollection.InsertOneAsync(document);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var documents = await _productsCollection.Find(new BsonDocument()).ToListAsync();
            return documents.Select(doc => new Product(
                doc["Name"].AsString,
                doc["Price"].AsDecimal,
                doc["Quantity"].AsInt32
            )).ToList();
        }

        public async Task<int> Count()
        {
            var count = await _productsCollection.CountDocumentsAsync(new BsonDocument());
            return (int)count;
        }

        public async Task<Product> SearchProductByName(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            var document = await _productsCollection.Find(filter).FirstOrDefaultAsync();
            if (document == null) return null;
            return new Product(
                document["Name"].AsString,
                document["Price"].AsDecimal,
                document["Quantity"].AsInt32
            );
        }

        public async Task DeleteProductByName(string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
            await _productsCollection.DeleteOneAsync(filter);
        }

        public async Task<bool> EditProductName(Product product, string newName)
        {
            if (string.IsNullOrEmpty(newName)) return false;
            var filter = Builders<BsonDocument>.Filter.Eq("Name", product.Name);
            var update = Builders<BsonDocument>.Update.Set("Name", newName);
            var result = await _productsCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> EditProductPrice(Product product, decimal newPrice)
        {
            if (newPrice <= 0) return false;
            var filter = Builders<BsonDocument>.Filter.Eq("Name", product.Name);
            var update = Builders<BsonDocument>.Update.Set("Price", newPrice);
            var result = await _productsCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> EditProductQuantity(Product product, int newQuantity)
        {
            if (newQuantity <= 0) return false;
            var filter = Builders<BsonDocument>.Filter.Eq("Name", product.Name);
            var update = Builders<BsonDocument>.Update.Set("Quantity", newQuantity);
            var result = await _productsCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
    }
}

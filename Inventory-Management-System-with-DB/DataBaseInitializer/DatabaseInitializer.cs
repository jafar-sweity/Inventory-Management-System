using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_with_DB.DataBaseInitializer
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString = DataBaseConnection.SQLMSConnection.ConnectionString;

        public DatabaseInitializer()
        {
            CreateProductsTableAsync().Wait();
        }

        public async Task CreateProductsTableAsync()
        {
            var query = """
                        IF  object_id('Products') IS  NULL
                        BEGIN
                           Create TABLE Products
                           (
                           Name NVARCHAR(50) NOT NULL ,
                           Quantity INT NOT NULL,
                           Price DECIMAL(18, 2) NOT NULL
                           )
                        END
                        """;

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);
            await command.ExecuteNonQueryAsync();
        }
    }
}

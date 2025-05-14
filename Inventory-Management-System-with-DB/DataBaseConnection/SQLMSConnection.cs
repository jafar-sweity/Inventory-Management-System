using Microsoft.Extensions.Configuration;

namespace Inventory_Management_System_with_DB.DataBaseConnection
{
    public class SQLMSConnection
    {
        private readonly IConfiguration _configuration;

        public SQLMSConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("SQLServer");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_with_DB.DataBaseConnection
{
    public class MongoDBConnection
    {
        public static string ConnectionString => "mongodb://localhost:27017";
        public static string DatabaseName => "InventoryDB";
    }
}

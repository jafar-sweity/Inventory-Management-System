using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_with_DB.DataBaseConnection
{
    public class SQLMSConnection
    {
        public static string ConnectionString => "Server = LAPTOP-49OTT63M\\SQLEXPRESS ; Database = InventoryDB ; Integrated Security = SSPI; TrustServerCertificate = True;";
    }
}

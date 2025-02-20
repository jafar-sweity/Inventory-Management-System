using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int QuantityInStock { get; set; }
        string ToString();
    }
}

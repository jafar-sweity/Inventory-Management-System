using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Interfaces
{
    public interface Iinventory
    {
        // add new product
        void AddProduct(IProduct product);

        //  retrieve All Porducts 
        List<IProduct> GetAllProducts();

        //  Edit the product 

        void EditProduct(string name);

        // Search for a product by name 
        IProduct SearchProductByName(string name);

        // Delete product by name
        void DeleteProductByName(string name);


    }
}

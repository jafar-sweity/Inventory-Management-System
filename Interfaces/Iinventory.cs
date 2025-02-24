using Inventory_Management_System.models;
using System.Collections.Generic;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventory
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        int Count();  // Added a Count method for efficiency
        Product SearchProductByName(string name);
        void DeleteProductByName(string name);

        // Separate methods for editing product properties
        bool EditProductName(Product product, string newName);
        bool EditProductPrice(Product product, decimal newPrice);
        bool EditProductQuantity(Product product, int newQuantity);
    }
}

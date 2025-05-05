using Inventory_Management_System.models;
using System.Collections.Generic;

namespace Inventory_Management_System.Interfaces
{
    public interface IInventory
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<int> Count();
        Task<Product> SearchProductByName(string name);
        Task DeleteProductByName(string name);
         
        Task<bool> EditProductName(Product product, string newName);
        Task<bool> EditProductPrice(Product product, decimal newPrice);
        Task<bool> EditProductQuantity(Product product, int newQuantity);
    }
}

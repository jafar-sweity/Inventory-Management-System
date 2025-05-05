using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    public class InventoryOperations
    {
        private readonly IInventory _inventory;

        public InventoryOperations(IInventory inventory)
        {
            _inventory = inventory;
        }

        public async Task AddProductAsync()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            var product = new Product(name, price, quantity);
            await _inventory.AddProduct(product);
            Console.WriteLine("Product added successfully!");
        }

        public async Task ViewAllProductsAsync()
        {
            List<Product> products = await _inventory.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public async Task CountProductsAsync()
        {
            int count = await _inventory.Count();
            Console.WriteLine($"Total number of products: {count}");
        }

        public async Task SearchProductAsync()
        {
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine();

            Product product = await _inventory.SearchProductByName(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.WriteLine("Product found:");
                Console.WriteLine(product);
            }
        }

        public async Task EditProductNameAsync()
        {
            Console.Write("Enter product name to edit: ");
            string name = Console.ReadLine();

            Product product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new product name: ");
            string newName = Console.ReadLine();

            bool updated = await _inventory.EditProductName(product, newName);
            Console.WriteLine(updated ? "Product name updated." : "Update failed.");
        }

        public async Task EditProductPriceAsync()
        {
            Console.Write("Enter product name to edit: ");
            string name = Console.ReadLine();

            Product product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            bool updated = await _inventory.EditProductPrice(product, newPrice);
            Console.WriteLine(updated ? "Product price updated." : "Update failed.");
        }

        public async Task EditProductQuantityAsync()
        {
            Console.Write("Enter product name to edit: ");
            string name = Console.ReadLine();

            Product product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new quantity: ");
            int newQty = int.Parse(Console.ReadLine());

            bool updated = await _inventory.EditProductQuantity(product, newQty);
            Console.WriteLine(updated ? "Product quantity updated." : "Update failed.");
        }

        public async Task DeleteProductAsync()
        {
            Console.Write("Enter product name to delete: ");
            string name = Console.ReadLine();

            try
            {
                await _inventory.DeleteProductByName(name);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

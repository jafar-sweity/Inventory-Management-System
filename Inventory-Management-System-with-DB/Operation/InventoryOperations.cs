using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;

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
            var name = Console.ReadLine();

            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price input.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity input.");
                return;
            }

            var product = new Product(name, price, quantity);
            await _inventory.AddProduct(product);
            Console.WriteLine("Product added successfully!");
        }

        public async Task ViewAllProductsAsync()
        {
            var products = await _inventory.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            Console.WriteLine("Available Products:");
            foreach (var product in products)
                Console.WriteLine(product);
        }

        public async Task CountProductsAsync()
        {
            var count = await _inventory.Count();
            Console.WriteLine($"Total number of products: {count}");
        }

        public async Task SearchProductAsync()
        {
            Console.Write("Enter product name to search: ");
            var name = Console.ReadLine();

            var product = await _inventory.SearchProductByName(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Product found:");
            Console.WriteLine(product);
        }

        public async Task EditProductNameAsync()
        {
            Console.Write("Enter product name to edit: ");
            var name = Console.ReadLine();

            var product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new product name: ");
            var newName = Console.ReadLine();

            var updated = await _inventory.EditProductName(product, newName);
            Console.WriteLine(updated ? "Product name updated." : "Update failed.");
        }

        public async Task EditProductPriceAsync()
        {
            Console.Write("Enter product name to edit: ");
            var name = Console.ReadLine();

            var product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var newPrice))
            {
                Console.WriteLine("Invalid price input.");
                return;
            }

            var updated = await _inventory.EditProductPrice(product, newPrice);
            Console.WriteLine(updated ? "Product price updated." : "Update failed.");
        }

        public async Task EditProductQuantityAsync()
        {
            Console.Write("Enter product name to edit: ");
            var name = Console.ReadLine();

            var product = await _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var newQty))
            {
                Console.WriteLine("Invalid quantity input.");
                return;
            }

            var updated = await _inventory.EditProductQuantity(product, newQty);
            Console.WriteLine(updated ? "Product quantity updated." : "Update failed.");
        }

        public async Task DeleteProductAsync()
        {
            Console.Write("Enter product name to delete: ");
            var name = Console.ReadLine();

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

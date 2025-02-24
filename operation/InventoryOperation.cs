using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using Inventory_Management_System.utilities;
using System;
using System.Collections.Generic;

namespace Inventory_Management_System.operation
{
    class InventoryOperation
    {
        private readonly Inventory _inventory;
        public InventoryOperation(Inventory inventory) => _inventory = inventory;
        public void AddProduct()
        {
            Menu.PrintTitle("ADD PRODUCT");

            var name = ReadValidName();
            if (name == null) return;

            var price = ReadValidDecimal("Enter Product Price: ");
            if (price == null) return;

            var quantityInStock = ReadValidInt("Enter Product Quantity in Stock: ");
            if (quantityInStock == null) return;

            _inventory.AddProduct(new Product(name, price.Value, quantityInStock.Value));
        }

        public void ViewAllProducts()
        {
            Menu.PrintTitle("ALL PRODUCTS");

            var products = _inventory.GetAllProducts(); // Store the result instead of calling twice
            if (products.Count == 0)
            {
                Console.WriteLine("No Products Found");
                Menu.BackToMenu();
                return;
            }

            products.ForEach(product => Console.WriteLine(product));
            Menu.BackToMenu();
        }

        public void DeleteProduct()
        {
            Menu.PrintTitle("DELETE PRODUCT");

            var name = ReadValidName();
            if (name == null) return;

            var product = _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                Menu.BackToMenu();
                return;
            }

            _inventory.DeleteProductByName(name);
            Console.WriteLine("Product Deleted Successfully");
            Menu.BackToMenu();
        }

        public void SearchProductByName()
        {
            Menu.PrintTitle("SEARCH PRODUCT");

            var name = ReadValidName();
            if (name == null) return;

            var product = _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
            }
            else
            {
                Console.WriteLine(product);
            }
            Menu.BackToMenu();
        }

        public void EditProduct()
        {
            Menu.PrintTitle("EDIT PRODUCT");

            var name = ReadValidName();
            if (name == null) return;

            var product = _inventory.SearchProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product Not Found");
                Menu.BackToMenu();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Edit Name");
                Console.WriteLine("2 - Edit Price");
                Console.WriteLine("3 - Edit Quantity in Stock");
                Console.WriteLine("4 - Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out var choice))
                {
                    Console.WriteLine("Invalid Choice! Enter a number.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        var newName = ReadValidName();
                        if (newName == null) return;
                        _inventory.EditProductName(product, newName);
                        Console.WriteLine("Name Updated Successfully");
                        break;

                    case 2:
                        var newPrice = ReadValidDecimal("Enter New Price: ");
                        if (newPrice == null) return;
                        _inventory.EditProductPrice(product, newPrice.Value);
                        Console.WriteLine("Price Updated Successfully");
                        break;

                    case 3:
                        var newQuantity = ReadValidInt("Enter New Quantity in Stock: ");
                        if (newQuantity == null) return;
                        _inventory.EditProductQuantity(product, newQuantity.Value);
                        Console.WriteLine("Quantity Updated Successfully");
                        break;

                    case 4:
                        Menu.PrintTitle("Product updated successfully");
                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Reads and validates a non-empty product name.
        /// </summary>
        private string ReadValidName()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Menu.PrintTitle("Product Name Is Required");
                Menu.BackToMenu();
                return null;
            }
            return name;
        }

        /// <summary>
        /// Reads and validates a decimal value from user input.
        /// </summary>
        private decimal? ReadValidDecimal(string message)
        {
            Console.Write(message);
            var isValidDecimal = decimal.TryParse(Console.ReadLine(), out var value);
            if (!isValidDecimal || value <= 0)
            {
                Menu.PrintTitle("Invalid input! Must be a number greater than 0.");
                Menu.BackToMenu();
                return null;
            }
            return value;
        }

        /// <summary>
        /// Reads and validates an integer value from user input.
        /// </summary>
        private int? ReadValidInt(string message)
        {
            Console.Write(message);
            var isValidInt = int.TryParse(Console.ReadLine(), out var value);
            if (!isValidInt || value <= 0)
            {
                Menu.PrintTitle("Invalid input! Must be a positive integer.");
                Menu.BackToMenu();
                return null;
            }
            return value;
        }
    }
}

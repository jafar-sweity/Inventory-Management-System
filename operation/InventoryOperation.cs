using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using Inventory_Management_System.utilities;
using Inventory_Management_System.Validation;
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
            Menu.PrintTitle(SuccessMessages.ProductAdded);
        }

        public void ViewAllProducts()
        {
            Menu.PrintTitle("ALL PRODUCTS");

            var products = _inventory.GetAllProducts();
            if (products.Count == 0)
            {
                Menu.PrintTitle(ErrorMessages.NoProductsFound);
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
                Menu.PrintTitle(ErrorMessages.ProductNotFound);
                Menu.BackToMenu();
                return;
            }

            _inventory.DeleteProductByName(name);
            Menu.PrintTitle(SuccessMessages.ProductDeleted);
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
                Menu.PrintTitle(ErrorMessages.ProductNotFound);
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
                Menu.PrintTitle(ErrorMessages.ProductNotFound);
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
                    Menu.PrintTitle(ErrorMessages.InvalidChoice);
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        var newName = ReadValidName();
                        if (newName == null) return;
                        _inventory.EditProductName(product, newName);
                        Menu.PrintTitle(SuccessMessages.NameUpdated);
                        break;

                    case 2:
                        var newPrice = ReadValidDecimal("Enter New Price: ");
                        if (newPrice == null) return;
                        _inventory.EditProductPrice(product, newPrice.Value);
                        Menu.PrintTitle(SuccessMessages.PriceUpdated);
                        break;

                    case 3:
                        var newQuantity = ReadValidInt("Enter New Quantity in Stock: ");
                        if (newQuantity == null) return;
                        _inventory.EditProductQuantity(product, newQuantity.Value);
                        Menu.PrintTitle(SuccessMessages.QuantityUpdated);
                        break;

                    case 4:
                        Menu.PrintTitle(SuccessMessages.ProductUpdated);
                        Console.ReadKey();
                        return;

                    default:
                        Menu.PrintTitle(ErrorMessages.InvalidChoice);
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

            if (!ProductValidator.ValidateName(name))
                return null;

            return name;
        }

        /// <summary>
        /// Reads and validates a decimal value from user input.
        /// </summary>
        private decimal? ReadValidDecimal(string message)
        {
            Console.Write(message);
            var isValidDecimal = decimal.TryParse(Console.ReadLine(), out var value);

            if (!isValidDecimal || !ProductValidator.ValidatePrice(value))
                return null;

            return value;
        }

        /// <summary>
        /// Reads and validates an integer value from user input.
        /// </summary>
        private int? ReadValidInt(string message)
        {
            Console.Write(message);
            var isValidInt = int.TryParse(Console.ReadLine(), out var value);

            if (!isValidInt || !ProductValidator.ValidateQuantity(value))
                return null;

            return value;
        }
    }
}

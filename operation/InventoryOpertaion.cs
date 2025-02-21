using Inventory_Management_System.Interfaces;
using Inventory_Management_System.models;
using Inventory_Management_System.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory_Management_System.operation
{
    class InventoryOpertaion
    {
        private readonly Inventory inventory;
        public InventoryOpertaion(Inventory inventory)
        {

            this.inventory = inventory;
        }

        public void AddProduct()
        {

            Menu.PrintTitle("ADD PRODUCT ");

            Console.WriteLine("Enter Product Name");
            string Name = Console.ReadLine();

            // lets check the name validation
            if (string.IsNullOrEmpty(Name))
            {
                Menu.PrintTitle("Prodcut Name Is Required");
                Menu.BackToMenu();

                return;
            }

            Console.WriteLine("Enter Product Price");
            decimal Price = Convert.ToDecimal(Console.ReadLine());

            if (Price <= 0)
            {
                Menu.PrintTitle("Product Price must be greater than 0");
                Menu.BackToMenu();
                return;
            }
            Console.WriteLine(
                "Enter Product Quantity in Stock"
            );
            int QuantityInStock = Convert.ToInt32(Console.ReadLine());
            if (QuantityInStock <= 0)
            {
                Menu.PrintTitle("Product Quantity must be greater than 0");
                Menu.BackToMenu();
            }
            IProduct product = new Product(Name, Price, QuantityInStock);
            inventory.AddProduct(product);


        }

        public void viewAllProducts()
        {
            Menu.PrintTitle("PRINT ALL PRODUCTS");

            if (inventory.GetAllProducts().Count == 0)
            {
                Console.WriteLine("No Products Found");
            }
            else
            {
                foreach (var product in inventory.GetAllProducts())
                {
                    Console.WriteLine(product.ToString());
                }
            }
            Menu.BackToMenu();
        }

        public void DeleteProduct()
        {
            Menu.PrintTitle("DELETE PRODUCT");
            Console.WriteLine("Enter Product Name to Delete");
            string Name = Console.ReadLine();

            if (string.IsNullOrEmpty(Name))
            {
               
                Menu.PrintTitle("Prodcut Name Is Required");

                Menu.BackToMenu();

                return;
            }
            if (inventory.SearchProductByName(Name) == null)
            {
                Console.WriteLine("Product Not Found");
                Menu.BackToMenu();

            }
            else
            {
                inventory.DeleteProductByName(Name);
                Console.WriteLine("Product Deleted Successfully");
                Menu.BackToMenu();

            }
        }

        public void SearchProductByName()
        {
            Menu.PrintTitle("SEARCH FOR PRODUCT");

            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Menu.PrintTitle("Prodcut Name Is Required");
                Menu.BackToMenu();
                return;
            }
            if (inventory.SearchProductByName(name) == null)
            {
                Console.WriteLine("Product Not Found");
                Menu.BackToMenu();
            }
            else
            {
                Console.WriteLine(inventory.SearchProductByName(name));
                Menu.BackToMenu();
                
            }
        }

        public void EditProduct()
        {
            Menu.PrintTitle("EDIT PRODUCT");
            Console.WriteLine("Enter Product Name to Edit");
            string Name = Console.ReadLine();
            if (string.IsNullOrEmpty(Name))
            {
                Menu.PrintTitle("Prodcut Name Is Required");
                Menu.BackToMenu();
                return;
            }

        
            IProduct product = inventory.SearchProductByName(Name);

            if (product == null)
            {
                Console.WriteLine(
                    "Product Not Found"
                );
                Menu.BackToMenu();
                return;
            }

            bool isEditing = true;

            while (isEditing)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to Edit Name");
                Console.WriteLine("Enter 2 to Edit Price");
                Console.WriteLine("Enter 3 to Edit Quantity in Stock");
                Console.WriteLine("Enter 4 to Exit");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter New Name");
                        string newName = Console.ReadLine();
                        if (string.IsNullOrEmpty(newName))
                        {
                            Menu.PrintTitle("Prodcut Name Is Required");
                            Menu.BackToMenu();
                            return;
                        }
                        product.Name = newName;
                        Console.WriteLine("Name Updated Successfully");

                        Console.ReadKey();

                        break;
                    case 2:
                        Console.WriteLine("Enter New Price");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        if (newPrice <= 0)
                        {
                            Menu.PrintTitle("Product Price must be greater than 0");
                            Menu.BackToMenu();
                            return;
                        }
                        product.Price = newPrice;
                        Console.WriteLine("Price Updated Successfully");
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.WriteLine("Enter New Quantity in Stock");
                        int newQuantityInStock = Convert.ToInt32(Console.ReadLine());
                        if (newQuantityInStock <= 0)
                        {
                            Menu.PrintTitle("Product Quantity must be greater than 0");
                            Menu.BackToMenu();
                            return;
                        }
                        product.QuantityInStock = newQuantityInStock;
                        Console.WriteLine("Quantity in Stock Updated Successfully");
                        Console.ReadKey();

                        break;
                    case 4:
                        isEditing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();

                        break;
                }
            }



        }
    }
    }
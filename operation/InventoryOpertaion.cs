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
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║              ADD PRODUCT               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");

            Console.WriteLine("Enter Product Name");
            string Name = Console.ReadLine();

            // lets check the name validation
            if (string.IsNullOrEmpty(Name))
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║    Product Name is required            ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

                Menu.BackToMenu();

                return;
            }

            Console.WriteLine("Enter Product Price");
            decimal Price = Convert.ToDecimal(Console.ReadLine());

            if (Price <= 0)
            {

                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║  Product Price must be greater than 0  ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

                Menu.BackToMenu();

                return;
            }
            Console.WriteLine(
                "Enter Product Quantity in Stock"
            );
            int QuantityInStock = Convert.ToInt32(Console.ReadLine());
            if (QuantityInStock <= 0)
            {
                Console.Clear();

                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║Product Quantity must be greater than 0 ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");
                Menu.BackToMenu();
            }
            IProduct product = new Product(Name, Price, QuantityInStock);
            inventory.AddProduct(product);


        }

        public void viewAllProducts()
        {
            Console.Clear();

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         PRINT ALL PRODUCT              ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

            if (inventory.GetAllProducts().Count == 0)
            {
                Console.WriteLine("No Product Found");
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
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║            Delete Product              ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

            Console.WriteLine("Enter Product Name to Delete");
            string Name = Console.ReadLine();

            if (string.IsNullOrEmpty(Name))
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║    Product Name is required            ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

                Menu.BackToMenu();

                return;
            }
            if(inventory.SearchProductByName(Name)==null)
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
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║           SEARCH FOR PRODUCT           ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║    Product Name is required            ║");
                Console.WriteLine("╚════════════════════════════════════════╝\n\n\n");

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
    }
    }
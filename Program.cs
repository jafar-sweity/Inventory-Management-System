using Inventory_Management_System.models;
using Inventory_Management_System.operation;
using Inventory_Management_System.utilities;

public class Program
{
    public static void Main(string[] args) { 

        bool exit = false;
        Inventory inventory = new Inventory();
        InventoryOpertaion inventoryOpertaion = new InventoryOpertaion(inventory);

        while (!exit)
        {
            Console.ResetColor();

            Menu.DisplayMenu();
            
            string choice = Console.ReadLine();


            switch(choice)
            {
                case "1":
                 inventoryOpertaion.AddProduct();
                    break;

                case "2":
                  inventoryOpertaion.viewAllProducts();
                    break;
                case "3":

                    break;
                case "4":
                    inventoryOpertaion.DeleteProduct();
                    break;
                case "5":
                    inventoryOpertaion.SearchProductByName();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Thank you for using the Inventory Management System. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
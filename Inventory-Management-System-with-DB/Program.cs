using Inventory_Management_System;
using Inventory_Management_System.Interfaces;
using Inventory_Management_System.Models;
using Inventory_Management_System_with_DB.DataBaseConnection;
using Inventory_Management_System_with_DB.DataBaseInitializer;
using Inventory_Management_System_with_DB.models;
using Inventory_Management_System_with_DB.Utilities;

class Program
{
    static async Task Main(string[] args)
    {

        IInventory inventory=null;

        Console.WriteLine("Select Inventory Type: 1. SQL  2. MongoDB");
        string inventoryChoice = Console.ReadLine();

        switch (inventoryChoice)
        {
            case "1":
                var sqlInitializer = new DatabaseInitializer();
                inventory = new InventorySQL(SQLMSConnection.ConnectionString);
                break;
            case "2":
                inventory = new InventoryMongoDB();
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to SQL Inventory.");
                inventory = new InventorySQL(SQLMSConnection.ConnectionString);
                break;
        }

        InventoryOperations operations = new InventoryOperations(inventory);

        bool exit = false;
        while (!exit)
        {
            MenuDisplay.ShowMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await operations.AddProductAsync();
                    break;
                case "2":
                    await operations.ViewAllProductsAsync();
                    break;
                case "3":
                    await operations.EditProductNameAsync();
                    break;
                case "4":
                    await operations.EditProductPriceAsync();
                    break;
                case "5":
                    await operations.EditProductQuantityAsync();
                    break;
                case "6":
                    await operations.DeleteProductAsync();
                    break;
                case "7":
                    await operations.SearchProductAsync();
                    break;
                case "8":
                    MenuDisplay.ShowExitMessage();
                    exit = true;
                    break;
                default:
                    MenuDisplay.ShowInvalidInputMessage();
                    break;
            }

            if (!exit)
            {
                MenuDisplay.ShowReturnToMenuMessage();
            }
        }
    }
}
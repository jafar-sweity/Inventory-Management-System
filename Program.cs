using Inventory_Management_System.utilities;

public class Program
{
    public static void Main(string[] args) { 

        bool exit = false;


        while (!exit)
        {
            Menu.DisplayMenu();

            string choice = Console.ReadLine();


            switch(choice)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
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
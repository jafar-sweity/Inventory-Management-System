using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.utilities
{
    public static class Menu
    {
        public static void DisplayMenu()
        {
        
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         INVENTORY MANAGEMENT           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\nWelcome to the Inventory Management System.");
            Console.WriteLine("Please select an option from the menu below:\n");
            Console.WriteLine("  [1] Add Product");
            Console.WriteLine("  [2] View All Products");
            Console.WriteLine("  [3] Edit Product");
            Console.WriteLine("  [4] Delete Product");
            Console.WriteLine("  [5] Search Product");
            Console.WriteLine("  [6] Exit");
            Console.WriteLine("\n--------------------------------------------");
            Console.Write("Your choice (1-6): ");
        }
    
    }
}

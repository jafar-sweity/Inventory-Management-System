using Inventory_Management_System.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Validation
{
    public static class ProductValidator
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Menu.PrintTitle("Product Name Is Required");
                Menu.BackToMenu();
                return false;
            }
            return true;
        }

        public static bool ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                Menu.PrintTitle("Product Price must be greater than 0");
                Menu.BackToMenu();
                return false;
            }
            return true;
        }

        public static bool ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                Menu.PrintTitle("Quantity must be a positive integer");
                Menu.BackToMenu();
                return false;
            }
            return true;
        }
    }

}

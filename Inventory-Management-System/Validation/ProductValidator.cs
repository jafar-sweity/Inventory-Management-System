using Inventory_Management_System.utilities;

namespace Inventory_Management_System.Validation
{
    public static class ProductValidator
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Menu.PrintTitle(ErrorMessages.ProductNameRequired);
                return false;
            }
            return true;
        }
        public static bool ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                Menu.PrintTitle(ErrorMessages.ProductPriceInvalid);
                return false;
            }
            return true;
        }
        public static bool ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                Menu.PrintTitle(ErrorMessages.ProductQuantityInvalid);
                return false;
            }
            return true;
        }
    }
}

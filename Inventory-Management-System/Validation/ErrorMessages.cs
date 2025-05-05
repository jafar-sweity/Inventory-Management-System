using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Validation
{
    public static class ErrorMessages
    {
        public const string ProductNameRequired = "Product Name is required!";
        public const string ProductPriceInvalid = "Invalid price! Must be a number greater than 0.";
        public const string ProductQuantityInvalid = "Invalid quantity! Must be a positive integer.";
        public const string InvalidChoice = "Invalid choice! Enter a valid number.";
        public const string ProductNotFound = "Product Not Found!";
        public const string NoProductsFound = "No Products Found!";
    }
}

namespace Inventory_Management_System.models
{
    public class Product  
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public Product(string name, decimal price, int quantityInStock)
        {
            Name = name;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public override string ToString()
        {
            return $"Name: {Name} | Price: {Price} |  Quantity in Stock: {QuantityInStock}";
        }
    }
}

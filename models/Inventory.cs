using Inventory_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_Management_System.models
{
    public class Inventory : IInventory
    {
        private readonly List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAllProducts() => _products;

        public int Count() => _products.Count; // New method to count products

        public Product SearchProductByName(string name)
        {
            return _products.Find(product => product.Name == name);
        }

        public bool EditProductName(Product product, string newName)
        {
            if (string.IsNullOrEmpty(newName)) return false;

            var productToEdit = SearchProductByName(product.Name);
            if (productToEdit == null) return false;

            productToEdit.Name = newName;
            return true;
        }

        public bool EditProductPrice(Product product, decimal newPrice)
        {
            if (newPrice <= 0) return false;

            var productToEdit = SearchProductByName(product.Name);
            if (productToEdit == null) return false;

            productToEdit.Price = newPrice;
            return true;
        }

        public bool EditProductQuantity(Product product, int newQuantity)
        {
            if (newQuantity <= 0) return false;

            var productToEdit = SearchProductByName(product.Name);
            if (productToEdit == null) return false;

            productToEdit.QuantityInStock = newQuantity;
            return true;
        }

        public void DeleteProductByName(string name)
        {
            _products.RemoveAll(product => product.Name == name);
        }
    }
}

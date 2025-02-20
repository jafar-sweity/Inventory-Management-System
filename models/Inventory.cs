using Inventory_Management_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.models
{
    class Inventory : Iinventory
    {
        private List<IProduct> _products = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }
        public List<IProduct> GetAllProducts()
        {
            return _products;
        }
        public void RemoveProduct(string name)
        {

        }

        public void EditProduct(string name)
        {
        }
        public void DeleteProductByName(string name)
        {
        }
        public IProduct SearchProductByName(string name)
        {

            return _products.Find(product => product.Name == name);

        }


    }
}
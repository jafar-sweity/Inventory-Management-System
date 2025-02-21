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
        private  List<IProduct> _products = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            
            _products.Add(product);
        }
        public List<IProduct> GetAllProducts()
        {
            return _products;
        }
      

        public void EditProduct(string name)
        {
            // if fie
        }
        public void DeleteProductByName(string name)
        {
            _products.RemoveAll(product => product.Name == name);
        }
        public IProduct SearchProductByName(string name)
        {

            return _products.Find(product => product.Name == name);

        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private List<ShoppingCartItem> _products;

        public ShoppingCart(Customer customer)
        {
            _customer = customer;
            _products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return  _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id) 
        {
            var prodId =
                from i in _products
                let productActual = i.GetProduct()
                where productActual.GetId() == id
                select i;
            
            return (ShoppingCartItem)prodId;
                                      
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                var item = new ShoppingCartItem(prod, quantity);
                var itemQ = item.GetQuantity();

                if (_products.Contains(item))
                {
                    var itemIn = _products.IndexOf(item);
                    _products[itemIn].SetQuantity(quantity + itemQ);
                    return _products[itemIn];
                }
                else 
                {
                  _products.Add(item);
                  var itemIn = _products.IndexOf(item);
                  return _products[itemIn];
                }                
            }
            else { return null; }

        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity > 0)
            {
                var item = GetProductById(id);
                var itemIn = _products.IndexOf(item);
                var itemQ = _products[itemIn].GetQuantity();

                if ((itemQ - quantity) <= 0)
                {
                    _products.RemoveAt(itemIn);

                    return item;
                }
                else { _products[itemIn].SetQuantity(itemQ - quantity); return _products[itemIn]; }                
            }
            else { return null; }


        }

        public decimal GetTotal()
        {
            var param = _products.Count();
            decimal total = 0;
            

            for(int count = 0; count <= param; count++)
            {
                var price = _products[count].GetTotal();
                total += price;
            }

            return total;
            
        }

        public List<ShoppingCartItem> GetProducts()
        {

            var itemsSorted =
                from i in _products
                orderby i
                select i;

            return (List<ShoppingCartItem>) itemsSorted;
           
        }
        
    }
}

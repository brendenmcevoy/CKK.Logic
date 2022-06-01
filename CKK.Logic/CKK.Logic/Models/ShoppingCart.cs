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
        private List<ShoppingCartItem> _cartItems;

        public ShoppingCart(Customer customer, ShoppingCartItem cartItem)
        {
            _customer = customer;
            _cartItems = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return  _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id) 
        {
            return _cartItems[id];
                                      
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            var item = new ShoppingCartItem(prod, quantity);
            var itemQ = item.GetQuantity();

            if (_cartItems.Contains(item))
            {
                item.SetQuantity(itemQ + quantity);
            }
            else { _cartItems.Add(item); }

            return item;
                                                                                          
        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            var itemQ = _cartItems[id].GetQuantity();
            
            if (quantity > 0)
            {
                var item = _cartItems[id];
                item.SetQuantity(itemQ - quantity);

                if (item.GetQuantity() <= 0)
                {
                    _cartItems.RemoveAt(id);                  
                }

                return item;
            }
            else { return null; }
        }

        public decimal GetTotal()
        {
            var param = _cartItems.Count();
            decimal total = 0;
            

            for(int count = 0; count <= param; count++)
            {
                var price = _cartItems[count].GetTotal();
                total += price;
            }

            return total;
            
        }

        public List<ShoppingCartItem> GetProducts ()
        {
            return _cartItems;
           
        }
        
    }
}

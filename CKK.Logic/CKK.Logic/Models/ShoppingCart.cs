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
            var prodId =
                from i in _cartItems
                let productActual = i.GetProduct()
                where productActual.GetId() == id
                select i;

            return (ShoppingCartItem)prodId;
                                      
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
            var prod = GetProductById(id);
            var prodIn = _cartItems.IndexOf(prod);
            var prodQ = _cartItems[prodIn].GetQuantity();
            _cartItems[prodIn].SetQuantity(prodQ - quantity);

            if(_cartItems[prodIn].GetQuantity() <= 0)
            {
                _cartItems[prodIn].SetQuantity(0);
                _cartItems.RemoveAt(prodIn);
            }

            return prod;
                      
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

            var itemsSorted =
                from i in _cartItems
                orderby i
                select i;

            return (List<ShoppingCartItem>) itemsSorted;
           
        }
        
    }
}

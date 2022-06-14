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

        
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                foreach (var i in _products)
                {
                    if (i.GetProduct() == prod)
                    {
                        i.SetQuantity(i.GetQuantity() + quantity);

                        return i;
                    }                    
                } 

                ShoppingCartItem newItem = new ShoppingCartItem(prod, quantity);
                _products.Add(newItem);
                return newItem;                             
            }
            return null;
                        
        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity > 0)
            {
                foreach (var i in _products)
                {
                    if (i.GetProduct().GetId() == id)
                    {
                        if(i.GetQuantity() - quantity > 0)
                        {
                            i.SetQuantity(i.GetQuantity() - quantity);
                            return i;
                        } else
                        {
                            i.SetQuantity(0);
                            _products.Remove(i); 
                            return i;
                        }                      
                    }                    
                }
                
            }
            return null;          
        }

        public ShoppingCartItem GetProductById(int id)
        {
            var prodId =
                from i in _products                
                where i.GetProduct().GetId() == id
                select i;

            return prodId.FirstOrDefault();

        }

        public decimal GetTotal()
        {
            decimal total = 0;
            
            
            for(int c = 0; c <= _products.Count(); c++)
            {
                total += _products[c].GetTotal();
            }

            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;          
        }
        
    }
}

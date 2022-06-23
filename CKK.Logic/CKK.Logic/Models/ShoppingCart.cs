using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private readonly Customer _customer;
        private readonly List<ShoppingCartItem> _products;

        public ShoppingCart(Customer customer)
        {
            _customer = customer;
            _products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return  _customer.Id;
        }

        
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                foreach (var i in _products)
                {
                    if (i.Product == prod)
                    {
                        i.Quantity += + quantity;

                        return i;
                    }                    
                } 

                ShoppingCartItem newItem = new(prod, quantity);
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
                    if (i.Product.Id == id)
                    {
                        if(i.Quantity - quantity > 0)
                        {
                            i.Quantity -= ( - quantity);
                            return i;
                        } else
                        {
                            i.Quantity = 0;
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
                where i.Product.Id == id
                select i;

            return prodId.FirstOrDefault();

        }

        public decimal GetTotal()
        {
            decimal total = 0;
            
            foreach (var i in _products)
            {
                total += i.GetTotal();
            }

            return total;
                       
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;          
        }
        
    }
}

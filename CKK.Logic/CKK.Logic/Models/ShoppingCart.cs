using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
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
                try
                {
                    foreach (var i in _products)
                    {
                        if (i.Product == prod)
                        {
                            i.Quantity += +quantity;

                            return i;
                        }
                    }

                    ShoppingCartItem newItem = new(prod, quantity);
                    _products.Add(newItem);
                    return newItem;
                }

                catch (InventoryItemStockTooLowException inventoryItemStocktooLowException)
                {
                    Console.WriteLine($"\n{inventoryItemStocktooLowException.Message}");                    
                }
            }
            else 
            {                
                throw new InventoryItemStockTooLowException();
            }
            return null;
        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            var prod = GetProductById(id);

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
            }

            if (_products.Contains(prod) == false)
            {
                throw new ProductDoesNotExistException();
            }

            try
            {
                foreach (var i in _products)
                {
                    if (i.Product.Id == id)
                    {
                        if (i.Quantity - quantity > 0)
                        {
                            i.Quantity -= (quantity);
                            return i;
                        }else                        
                        {
                            i.Quantity = 0;
                            _products.Remove(i);
                            return i;
                        }
                    }                    
                }
            }catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine($"\n{argumentOutOfRangeException.Message}");

            }
            catch (ProductDoesNotExistException productDoesNotExistException)
            {
                Console.WriteLine($"\n{productDoesNotExistException.Message}");
            }                           
            return null;          
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            try
            {
                var prodId =
                    from i in _products
                    where i.Product.Id == id
                    select i;

                return prodId.FirstOrDefault();

            }catch(InvalidIdException invalidIdException)
            {
                Console.WriteLine($"\n {invalidIdException.Message}");                
            }
            return null;
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

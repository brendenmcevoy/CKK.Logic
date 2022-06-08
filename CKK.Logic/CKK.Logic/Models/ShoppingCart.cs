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

                var findProd =
                    from p in _products
                    let isProd = p.GetProduct()
                    where isProd == prod
                    select isProd;
              
                if (findProd != null)
                {
                    var _index = _products.IndexOf((ShoppingCartItem)findProd);
                    var prodQ = _products[_index].GetQuantity();
                    _products[_index].SetQuantity(prodQ + quantity);

                    return _products[_index];
                }
                else 
                {
                    var p1 = new ShoppingCartItem(prod, quantity);
                    _products.Add(p1);
                    

                    return p1;
                }                
            }
            else { return null; }

        }


        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity > 0)
            {
                var item = GetProductById(id);
                var _index = _products.IndexOf(item);
                var itemQ = _products[_index].GetQuantity();

                if ((itemQ - quantity) <= 0)
                {
                    _products.RemoveAt(_index);
                    item.SetQuantity(0);

                    return item;
                }
                else 
                {
                    _products[_index].SetQuantity(itemQ - quantity);

                    return _products[_index];
                }                
            }
            else { return null; }


        }

        public ShoppingCartItem GetProductById(int id)
        {
            var prodId =
                from i in _products
                let productActual = i.GetProduct()
                where productActual.GetId() == id
                select productActual;

            return (ShoppingCartItem)prodId;

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

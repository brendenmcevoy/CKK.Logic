using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    internal interface IShoppingCart
    {

        public abstract int GetCustomerId();

        public abstract ShoppingCartItem AddProduct(Product prod, int id);

        public abstract ShoppingCartItem RemoveProduct(int id, int quantity);

        public abstract decimal GetTotal();

        public abstract ShoppingCartItem GetProductById(int id);

        public abstract List<ShoppingCartItem> GetProducts();
        
            
        
        

        
    }
}

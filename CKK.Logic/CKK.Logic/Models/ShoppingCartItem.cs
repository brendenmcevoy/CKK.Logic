using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem : InventoryItem
    {        
        public ShoppingCartItem(Product product, int quantity) : base(product, quantity)  
        {
            
        }

        
        public decimal GetTotal()
        {            
            decimal price = Product.Price;
            decimal total = Quantity * price;
            return total;           
        }
    }
}

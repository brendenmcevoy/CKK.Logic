using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        private Product product;
        private int quantity;

        public InventoryItem(Product Product, int Quantity)
        {
            product = Product;
            quantity = Quantity;
        }
     
        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }

        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                else { quantity = value; }
                
            }
        }
    }
}

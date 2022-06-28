using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Store : Entity , IStore
    {
        
        private readonly List<StoreItem> _items;


        public Store ()
        {
            _items = new List<StoreItem>();
            
        }
        
        public StoreItem AddStoreItem(Product prod, int quantity)
        {

            if (quantity > 0)
            {

                foreach (StoreItem i in _items)
                {
                    if (i.Product == prod)
                    {
                        i.Quantity +=  + quantity;
                        return i;
                    }
                }

                StoreItem newItem = new(prod, quantity);
                _items.Add(newItem);
                return newItem;            
            }
            return null;

        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity > 0)
            {
                foreach (var i in _items)
                {
                    if (i.Product.Id == id)
                    {
                        if (i.Quantity - quantity > 0)
                        {
                            i.Quantity -= quantity;
                            return i;
                        }
                        else
                        {
                            i.Quantity = 0;
                            return i;
                        }
                    }
                                                                         
                }                

            } return null;
                              
        }

        public List<StoreItem> GetStoreItems()
        {            
            return _items;
        }

        public StoreItem FindStoreItemById(int id)
        {

            var itemId =
                from i in _items
                where i.Product.Id == id
                select i;
           
            return itemId.FirstOrDefault();
        }                        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int _id;
        private string _name;
        private List<StoreItem> _items;

        public Store ()
        {
            _items = new List<StoreItem>();
            
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {           
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                var item = new StoreItem(prod, quantity);
                var itemQ = item.GetQuantity();

                if (_items.Contains(item))
                {
                    var itemIn = _items.IndexOf(item);
                    _items[itemIn].SetQuantity(quantity + itemQ);
                }else { _items.Add(item); }

                var itemIndex = _items.IndexOf(item);
                return _items[itemIndex];
            }
            else { return null; }
                              
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity > 0)
            {
                var item = FindStoreItemById(id);
                var itemIn = _items.IndexOf(item);
                var itemQ = _items[itemIn].GetQuantity();

                if((itemQ - quantity) <= 0)
                {
                    _items[itemIn].SetQuantity(0);
                }
                else { _items[itemIn].SetQuantity(itemQ - quantity); }

                return _items[itemIn];
            }
            else { return null; }            
                       
        }

        public List<StoreItem> GetStoreItems()
        {
            var itemsSorted =
                from i in _items
                orderby i
                select i;

            return (List<StoreItem>)itemsSorted;
        }

        public StoreItem FindStoreItemById(int id)
        {

            var itemId =
                from i in _items
                let productActual = i.GetProduct()
                where productActual.GetId() == id
                select i;
           
            return (StoreItem)itemId;
        }

        

        

        
    }
}

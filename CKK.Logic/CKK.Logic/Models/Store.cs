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
            var item = new StoreItem(prod, quantity);
            var itemQ = item.GetQuantity();

            if (_items.Contains(item))
            {
                item.SetQuantity(itemQ + quantity);
            }
            else { _items.Add(item); }

            return item;
                              
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            
            var item = FindStoreItemById(id);
            var itemIn = _items.IndexOf(item);
            var itemQ = _items[itemIn].GetQuantity();
            _items[itemIn].SetQuantity(itemQ - quantity);
                     
            if (_items[itemIn].GetQuantity() <= 0 )
            {
                _items[itemIn].SetQuantity(0);
            }
                                                                              
            return _items[itemIn];
                       
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

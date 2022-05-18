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
        private List<StoreItem> _storeItem;

        public Store(StoreItem storeItem)
        {
            _storeItem = new List<StoreItem>();
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

            if (_storeItem.Contains(item))
            {
                item.SetQuantity(itemQ + quantity);
            }
            else { _storeItem.Add(item); }

            
                       
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var itemQ = _storeItem[id].GetQuantity();
                     
            _storeItem[id].SetQuantity(itemQ - quantity);
                       
        }

        public List<StoreItem> GetStoreItems()
        {
            return _storeItem;
                                    
        }

        public StoreItem FindStoreItemById(int id)
        {      
            return _storeItem[id];
        }

        

        

        
    }
}

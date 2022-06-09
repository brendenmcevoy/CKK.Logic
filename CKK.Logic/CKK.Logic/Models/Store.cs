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

                foreach (StoreItem i in _items)
                {
                    if (i.GetProduct() == prod)
                    {
                        i.SetQuantity(i.GetQuantity() + quantity);
                        return i;
                    }
                }

                StoreItem newItem = new StoreItem(prod, quantity);
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
                    if (i.GetProduct().GetId() == id)
                    {
                        if (i.GetQuantity() - quantity > 0)
                        {
                            i.SetQuantity(i.GetQuantity() - quantity);
                            return i;
                        }
                        else
                        {
                            i.SetQuantity(0);
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
                where i.GetProduct().GetId() == id
                select i;
           
            return itemId.FirstOrDefault();
        }                        
    }
}

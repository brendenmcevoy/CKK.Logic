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
            if (quantity >= 0)
            {
                var findProd =
                    from i in _items                    
                    where i.GetProduct() == prod
                    select i; 
                
                var foundProd = findProd.FirstOrDefault();

                if ( _items.Contains(foundProd))
                {
                    var _index = _items.IndexOf(foundProd);
                    var prodQ = _items[_index].GetQuantity();
                    _items[_index].SetQuantity(prodQ + quantity);

                    return _items[_index];
                }
                else
                {
                    var item = new StoreItem(prod, quantity);
                    _items.Add(item);

                    return item;
                }

            }else { return null; }                                                         
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity >= 0)
            {

                var item = FindStoreItemById(id);
                var _index = _items.IndexOf(item);
                var itemQ = _items[_index].GetQuantity();

                if ((itemQ - quantity) <= 0)
                {
                    _items[_index].SetQuantity(0);

                    return _items[_index];
                }
                else
                {
                    _items[_index].SetQuantity(itemQ - quantity);

                    return _items[_index];
                }
            }
            else { return null; }    
        }

        public List<StoreItem> GetStoreItems()
        {
            var itemsSorted =
                from i in _items
                orderby i
                select i;

            return itemsSorted.ToList();
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

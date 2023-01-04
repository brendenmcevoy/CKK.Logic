using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

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
            Random rnd = new Random();
            if(prod.Id == 0)
            {
                prod.Id = rnd.Next(0,100);
            }

            if (quantity <= 0)
            { throw new InventoryItemStockTooLowException(); }
                try
                {
                    foreach (StoreItem i in _items)
                    {
                        if (i.Product == prod)
                        {
                            i.Quantity += +quantity;
                            return i;
                        }
                    }

                    StoreItem newItem = new(prod, quantity);
                    _items.Add(newItem);
                    return newItem;

                }catch(InventoryItemStockTooLowException inventoryItemStockTooLowException)
                {
                    Console.WriteLine($"\n{inventoryItemStockTooLowException.Message}");
                }               
            return null;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var item = FindStoreItemById(id);

            if (quantity <= 0)
            { throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero."); }

            if (_items.Contains(item) == false)
            {
                throw new ProductDoesNotExistException();
            }

            try
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
            }catch(ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine($"\n{argumentOutOfRangeException.Message}");               

            }catch(ProductDoesNotExistException productDoesNotExistException)
            {
                Console.WriteLine($"\n{productDoesNotExistException.Message}");
            }
            return null;                             
        }

        public void DeleteStoreItem(int id)
        {
            
            _items.Remove(FindStoreItemById(id));
        }

        public List<StoreItem> GetStoreItems()
        {            
            return _items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            try
            {
                var itemId =
                    from i in _items
                    where i.Product.Id == id
                    select i;

                return itemId.FirstOrDefault();

            }catch(InvalidIdException invalidIdException)
            {
                Console.WriteLine($"\n{invalidIdException.Message}");
            }
            return null;
        }
        public List<StoreItem> GetAllProductsByName(string name)
        {
            List<StoreItem> searchList = new List<StoreItem>();

            for (var index = 0; index < _items.Count; ++index)
            {
                string temp = _items[index].Product.Name;

                if (temp.Substring(0, 3) == name.Substring(0, 3))
                {
                    searchList.Add(_items[index]);
                    return searchList;
                }
            }
            return searchList;
        }
        public List<StoreItem> GetProductsByQuantity()
        {
            int length = _items.Count;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < length - 1; i++)
                {
                    if (_items[i].Quantity < _items[i + 1].Quantity)
                    {
                        var temp = _items[i];
                        _items[i] = _items[i + 1];
                        _items[i + 1] = temp;
                        sorted = false;
                    }
                }
            }
            return _items;
        }
        public List<StoreItem> GetProductsByPrice()
        {
            int length = _items.Count;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < length - 1; i++)
                {
                    if (_items[i].Product.Price < _items[i + 1].Product.Price)
                    {
                        var temp = _items[i];
                        _items[i] = _items[i + 1];
                        _items[i + 1] = temp;
                        sorted = false;
                    }
                }
            }
            return _items;
        }
    }
}

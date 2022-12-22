using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore,ISavable,ILoadable
    {
        private readonly List<StoreItem> _items;
        private BinaryFormatter formatter;
        
        private FileStream stream;
        public FileStore()
        {
            _items = new List<StoreItem>();
            CreatePath();
        }

        public readonly string FilePath = @"C:\Users\beanwater\Documents\Persistance\StoreItems.dat";
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            Random rnd = new Random();
            if (prod.Id == 0)
            {
                prod.Id = rnd.Next(0, 100);
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
                Save();

            }
            catch (InventoryItemStockTooLowException inventoryItemStockTooLowException)
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
                            Save();
                        }
                        else
                        {
                            i.Quantity = 0;
                            return i;
                            Save();
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine($"\n{argumentOutOfRangeException.Message}");

            }
            catch (ProductDoesNotExistException productDoesNotExistException)
            {
                Console.WriteLine($"\n{productDoesNotExistException.Message}");
            }
            return null;
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

            }
            catch (InvalidIdException invalidIdException)
            {
                Console.WriteLine($"\n{invalidIdException.Message}");
            }
            return null;
        }
        public List<StoreItem> GetStoreItems()
        {
            return _items;
        }
        public void DeleteStoreItem(int id)
        {
            _items.Remove(FindStoreItemById(id));
            Save();
        }
        public void CreatePath()
        {
            stream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Save()
        {
            formatter.Serialize(stream, _items);
        }
        public void Load()
        {
             List<StoreItem> _items = (List<StoreItem>)formatter.Deserialize(stream); 

        }
    }
}

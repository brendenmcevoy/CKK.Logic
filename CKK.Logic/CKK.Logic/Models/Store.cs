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
            if (quantity <= 0)
            { throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero."); }
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
                    else { throw new ProductDoesNotExistException(); }

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
    }
}

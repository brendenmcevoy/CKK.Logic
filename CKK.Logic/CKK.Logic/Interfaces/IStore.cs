using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    internal interface IStore
    {
        public abstract StoreItem AddStoreItem(Product prod, int quantity);

        public abstract StoreItem RemoveStoreItem(int id, int quantity);

        public abstract StoreItem FindStoreItem(int id);

        public abstract List<StoreItem> GetStoreItems();
    } 
    
}

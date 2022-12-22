using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException() : base("Item inventory quantity must be greater than zero.")
        {

        }

        public InventoryItemStockTooLowException(string messageValue) : base(messageValue)
        {

        }

        public InventoryItemStockTooLowException(string messageValue, Exception inner) : base(messageValue, inner)
        {

        }
    }
}

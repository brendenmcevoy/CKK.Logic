using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}   NAME: {Name}    QUANTITY: {Quantity}    PRICE: ${Price}"; //Format for displaying in ListBox (CKK.UI)
        }
    }
}

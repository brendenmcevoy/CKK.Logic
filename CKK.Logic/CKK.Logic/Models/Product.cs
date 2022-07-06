using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {    
        private decimal _price;
        
        public decimal Price
        {
            get { return _price; }
            set
            {
                try { _price = value; }
                catch(ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.WriteLine($"\n{argumentOutOfRangeException.Message}");
                }

                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), _price, "Price must be greater than zero.");
                }
            }
        }
    }

}

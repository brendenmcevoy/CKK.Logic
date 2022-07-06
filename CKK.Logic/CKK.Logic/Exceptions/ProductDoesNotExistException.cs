using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException() : base()
        {

        }

        public ProductDoesNotExistException(string messageValue) : base(messageValue)
        {

        }

        public ProductDoesNotExistException(string messageValue, Exception inner) : base(messageValue, inner)
        {

        }
    }
}

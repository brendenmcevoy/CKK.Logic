using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    class InvalidIdException : Exception
    {public InvalidIdException() : base()
        {

        }

        public InvalidIdException(string messageValue) : base(messageValue)
        {

        }

        public InvalidIdException(string messageValue, Exception inner) : base(messageValue, inner)
        {

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        private int id;
        private string name;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id < 0)
                {
                    throw new InvalidIdException();
                }
                else { id = value; }

            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}

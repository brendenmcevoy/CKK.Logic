﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }     

}

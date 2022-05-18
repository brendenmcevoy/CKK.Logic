using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Customer
    {
        private int _id;
        private string _name;
        private string _address;

        //method that retrieves ID from the object
        public int GetId()
        {
            return _id;
        }

        //method that sets the ID in the object
        public void SetId(int id)
        {
            _id = id; 
        }

        //method that retrieves name from the object
        public string GetName()
        {
            return _name;
        }

        //method that sets the name in the object
        public void SetName(string name)
        {
            _name = name;
        }

        //method that retrieves address fom the object
        public string GetAddress()
        {
            return _address;
        }

        //method that sets the address in the object
        public void SetAddress(string address)
        {
            _address = address;
        }
    }

}

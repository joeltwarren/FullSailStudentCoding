using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Employee : IComparable
    {
        private string _name;
        private string _address;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
        }

        public Employee(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public int CompareTo(object obj)
        { 
            Employee otherEmployee = obj as Employee;
            if (otherEmployee != null)
                return _name.CompareTo(otherEmployee._name);
            else
                throw new ArgumentException("Object is not a Employee.");
        }
        public virtual decimal CalculatePay()
        {
            return 0;
        }

    }
}

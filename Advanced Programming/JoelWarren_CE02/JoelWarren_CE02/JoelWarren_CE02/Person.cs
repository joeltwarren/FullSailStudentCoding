using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE02
{
    class Person
    {
        private string _name;
        private string _description;
        private int _age;

        public Person(string name, string description, int age)
        {
            _name = name;
            _description = description;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public int Age
        {
            get { return _age; }
        }
    }
   
}

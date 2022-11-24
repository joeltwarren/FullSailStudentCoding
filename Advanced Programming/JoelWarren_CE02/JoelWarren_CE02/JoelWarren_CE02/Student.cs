using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE02
{
    class Student : Person
    {
        private int _grade;

        // allowing the base class to go ahead and process this using its own constructor
        public Student(string name, string description, int age) : base(name, description, age)
        {

        }

        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE02
{
    class Teacher : Person
    {
        private string [] _teachersKnowledge;

       


        public Teacher (string name, string description, int age) : base(name, description, age)
        {
            
        }

        public string[] TeachersKnowledge
        {
            get { return _teachersKnowledge; }
            set { _teachersKnowledge = value; }
        }
    }
}

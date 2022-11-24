using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE09
{
    class Customer
    { 
        private string _Name;
        
        public string Name
        {
            get { return _Name; }
        }

        public Customer(string name)
        {
            _Name = name;
            Program.GetLogger().LogW($"Customer: {_Name} was created.");
        }
        
    }
}

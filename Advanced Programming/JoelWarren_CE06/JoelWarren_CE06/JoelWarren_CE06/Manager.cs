using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Manager : Salaried
    {
        private decimal _bonus; // yearly bonus

        public Manager(string name, string address, decimal salary, decimal bonus) : base(name, address, salary)
        {
            _bonus = bonus;
        }

        public override decimal CalculatePay()
        {
            
            return GetSalary + _bonus;
        }
    }
}

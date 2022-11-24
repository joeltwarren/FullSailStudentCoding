using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Salaried : Employee
    {
        private decimal _salary;

        public Salaried(string name, string address, decimal salary):base(name, address)
        {
            _salary = salary;
        }

        public decimal GetSalary
        {
            get
            {
                return _salary;
            }

        }

        public override decimal CalculatePay()
        {
            return _salary;
        }
    }
}

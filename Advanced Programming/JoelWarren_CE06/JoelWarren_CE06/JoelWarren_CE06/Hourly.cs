using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Hourly : Employee
    {
        private decimal _payPerHour;
        private decimal _hoursPerWeek;

        public  decimal PayperHour
        {
            get
            {
                return _payPerHour;
            }
        }

        public decimal HoursPerWeek
        {
            get
            {
                return _hoursPerWeek;
            }
        }

        public Hourly(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address)
        {
            _payPerHour = payPerHour;
            _hoursPerWeek = hoursPerWeek;
        }

        public override decimal CalculatePay()
        {
            decimal yearlyPay = (_payPerHour * _hoursPerWeek) * 52;
            return yearlyPay;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class PartTime : Hourly
    {
        public PartTime(string name, string address, decimal payPerHour, decimal hoursPerWeek) : base(name, address, payPerHour, hoursPerWeek)
        {

        }

        public override decimal CalculatePay()
        {
            return base.CalculatePay();
        }
    }
}

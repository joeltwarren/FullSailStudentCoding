using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class FullTime : Hourly
    {
        public FullTime(string name, string address, decimal payPerHour) : base(name, address, payPerHour, 40)
        {

        }

        public override decimal CalculatePay()
        {
            return base.CalculatePay();
        }
    }
}

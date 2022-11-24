using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Contractor : Hourly
    {
        private decimal _noBenefitsBonus; // paid 10 to 15% more because they do not receive benefits

        public Contractor(string name, string address, decimal payPerHour, decimal hoursPerWeek, decimal noBenefitsBonus) : base(name, address, payPerHour, hoursPerWeek)
        {
            _noBenefitsBonus = noBenefitsBonus;
        }

        public override decimal CalculatePay()
        {
            return base.CalculatePay() + _noBenefitsBonus;
        }
    }
}

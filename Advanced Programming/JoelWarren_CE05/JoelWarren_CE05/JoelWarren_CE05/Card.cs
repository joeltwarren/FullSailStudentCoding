using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE05
{
    public class Card
    {
        private string _name;
        private string _description;
        private decimal _value;


        //public string Name
        //{
        //    get { return _name; }
        //    //set { _name = value; }
        //}
        //public string Description
        //{
        //    get { return _description; }
        //    //set { _description = value; }
        //}
        //public decimal Value
        //{
        //    get { return _value; }
        //    //set { _value = value; }
        //}

        public Card(string name, string description, decimal value)
        {
            _name = name;
            _description = description;
            _value = value;
        }

        public override string ToString()
        {
            string cardDetails;
            cardDetails =
"//=======================================\\\\\n"+
$"\tName: {_name}\n\tDescription: {_description}\n\tValue: {_value.ToString("C")}\n"+
"\\\\=======================================//\n";
            return cardDetails;
        }
    }
}

                    
                    

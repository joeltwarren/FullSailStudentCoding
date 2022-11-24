using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE08
{
    class DVD
    {
        private string _Title;
        private decimal _Price;
        private float _Rating;

        public DVD(string title, decimal price, float rating)
        {
            _Title = title;
            _Price = price;
            _Rating = rating;
        }
         public override string ToString()
        {
            string dvdData = $"Title: {_Title}\nPrice: {_Price.ToString("C")}\nRating: {_Rating.ToString()}";
            return dvdData;
        }
    }
}

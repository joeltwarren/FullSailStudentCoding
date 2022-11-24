using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE03
{
    class Car
    {
        private string _make;
        private string _model;
        private string _color;
        private float _mileage;
        private int _year;

        public string Make
        {
            get
            {
                return _make;
            }
            //set
            //{
            //    _make = value;
            //}
        }

        public string Model
        {
            get
            {
                return _model;
            }
            //set
            //{
            //    _model = value;
            //}
        }

        public string Color
        {
            get
            {
                return _color;
            }
            //set
            //{
            //    _color = value;
            //}
        }

        public float Mileage
        {
            get
            {
                return _mileage;
            }
            //set
            //{
            //    _mileage = value;
            //}
        }

        public int Year
        {
            get
            {
                return _year;
            }
            //set
            //{
            //    _year = value;
            //}
        }

        public Car()
        {

        }
        public Car(string make, string model, string color, float mileage, int year)
        {
            _make = make;
            _model = model;
            _color = color;
            _mileage = mileage;
            _year = year;
            Program.GetLogger().LogD($"The {year} {color} {make} {model} with {mileage.ToString()} miles was created!");
        }

        public void Drive(float driven)
        {
            _mileage += driven;
            Program.GetLogger().LogW($"The {_year} {_color} {_make} {_model}'s mileage was updated to {_mileage} miles.");
        }



    }
}

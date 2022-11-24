using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVP1.CE1
{
    class ValidDate
    {
        public static bool IsDateValid(string _usersInput) {
            
            // created a bool variable for using to determin a valid date
            bool isValid = false;
            
            // getting todays date and time.
            DateTime today = DateTime.Now;

            // set a value that the user cannot be older than to correct the tryparse setting the default 
            // value to 0001,01,01,12,0,0 or (1/1/0001 12:00:00)
            DateTime maxDate = new DateTime(1908, 1, 1, 0, 0, 0);

            // checking to see if the date entered is between now and jan 1st 1908
            if (DateTime.TryParse(_usersInput, out DateTime result) == false)
            {
                isValid = false;
               
            }
            else {
                isValid = true;
               
            }

            // creating a two variable to compare the entered date to
            int comparrison = DateTime.Compare(result, today);
            int secondComparrison = DateTime.Compare(result, maxDate);
            
            // final check that says if the date is not today and is before 1908 its true
            // compare gives 3 possible outcomes involving 0 greater than, less than, and equal to 0
            if (comparrison < 0 && secondComparrison > 0) {
                isValid = true;
            } else if (comparrison == 0) {
                isValid = false;
                

            } else {
                isValid = false;
                
            }

            // returning the result to the age convert class where this method is called.
            return isValid;
            
        }
    }
}

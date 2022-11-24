using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JoelWarren_CE03
{
    class Validation
    {
        // checks for a valid int and has a default message that can be dynamically changed
        public static int GetInt(string message = "Enter a number: ")
        {
            int validatedInt;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!Int32.TryParse(input, out validatedInt));

            return validatedInt;



        }
        // Method Overloading this is the same method except it requires 2 additional peices of Information..
        // setting a variable in the paramters section makes it a optional paramater
        // this means you have to supply it each paramater that does not have a default value assigned.
        // optional parameters must be on the right side and comes from right to left.
        public static int GetIntGreaterThanEqualToMin(int min = 0, int max = int.MaxValue, string message = "Enter a number: ")
        {
            int validatedInt;
            string input = null;
            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!(Int32.TryParse(input, out validatedInt) && (validatedInt >= min && validatedInt <= max)));

            return validatedInt;

        }

        public static decimal GetDecimalGreaterThanEqualToMin(decimal min = 0, decimal max = decimal.MaxValue, string message = "Enter a number: ")
        {
            decimal validatedDecimal;
            string input = null;
            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!(decimal.TryParse(input, out validatedDecimal) && (validatedDecimal >= min && validatedDecimal <= max)));

            return validatedDecimal;

        }

        // true / false check
        public static bool GetBool(string message = "Enter yes or no: ")
        {
            bool answer = false;
            string input = null;

            bool needAValidResponse = true;

            while (needAValidResponse)
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                    case "y":
                    case "true":
                    case "t":
                        {
                            answer = true;
                            needAValidResponse = false;
                        }
                        break;

                    case "no":
                    case "n":
                    case "false":
                    case "f":
                        {
                            answer = false;
                            needAValidResponse = false;
                        }
                        break;

                }


            }
            return answer;

        }

        // doubles validation
        public static double GetDouble(string message = "Enter a number: ")
        {
            double validatedDouble;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!double.TryParse(input, out validatedDouble));


           


            return validatedDouble;



        }
        // Method Overloading this is the same method except it requires 2 additional peices of Information..
        // setting a variable in the paramters section makes it a optional paramater
        // this means you have to supply it each paramater that does not have a default value assigned.
        // optional parameters must be on the right side and comes from right to left.
        public static double GetDoubleGreaterThanEqualToMin(double min = 0, double max = double.MaxValue, string message = "Enter a number: ")
        {
            double validatedDouble;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!(double.TryParse(input, out validatedDouble) && (validatedDouble >= min && validatedDouble <= max)));

            return validatedDouble;



        }

        // Float Validation
        public static float GetFloat(string message = "Enter a number: ")
        {
            float validatedFloat;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!float.TryParse(input, out validatedFloat));

            return validatedFloat;



        }

        // Method Overloading this is the same method except it requires 2 additional peices of Information..
        // setting a variable in the paramters section makes it a optional paramater
        // this means you have to supply it each paramater that does not have a default value assigned.
        // optional parameters must be on the right side and comes from right to left.
        public static float GetFloatGreaterThanEqualToMin(float min = 0, float max = float.MaxValue, string message = "Enter a number: ")
        {
            float validatedFloat;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!(float.TryParse(input, out validatedFloat) && (validatedFloat >= min && validatedFloat <= max)));

            return validatedFloat;



        }
        // Using IsNullOrWhiteSpace to check for just a blank empty string.
        public static string CheckforBlank(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;

        }

        // updated to include removing spaces before and after text inputs
        // Used to check for a blank string array during a console.readline() and removing spaces as well as special characters all of them.
        public static string StringTrimAndSpecialsRemoved(string message = "Please type something: ")
        {
            string input = "";

            while (input == "")
            {
                Console.Write(message);
                input = Console.ReadLine().Trim();
            }

            char[] delimiters = new char[] { ' ', ',','/','\\','}','{','"','.','<','>','?',':',';','@','!','#','$','%','^','&','*','(',')','_','-','=','+','|','~','`' };

            //input = string.Join(" ", input);
            string[] inputArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            input = string.Join(" ",inputArray);

            return input;
        }

        
    }
}

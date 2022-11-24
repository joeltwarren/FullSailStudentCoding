using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE_01
{
    class Validation
    {
        // this has a default message so that I can change it on the fly as needed in the main
        // validation for the menu's I create using Arrays of Valid Choices
        public static int ValidArrayMenuSelection(string selection, int[] validChoices, string message = "Please Enter a Valid Menu Option: ")
        {
            // string for the users input
            string usersSelection = selection;
            // int to store the tryparse set to below 0 for safety
            int usersIntSelection = -1;
            // array of intergers to accept the valid choices from the main program
            int[] valid = validChoices;
            // while loop Test for valid choice picked and confirm it can be tryparsed to an int
            while (!(Int32.TryParse(usersSelection, out usersIntSelection) && valid.Contains(usersIntSelection)))
            {
                Console.Write(message);
                usersSelection = Console.ReadLine();

            }
            // returning the validated Interger
            return usersIntSelection;

        }
        // custom interger Validation that allows for the users prompt to be passed to the method as a string, do loop executes the code once then the while loop keeps it going until input is valid
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
        // custom deciaml Validation that allows for the users prompt to be passed to the method as a string, do loop executes the code once then the while loop keeps it going until input is valid

        public static decimal GetDecimal(string message = "Enter a number: ")
        {
            decimal validatedDecimal;
            string input = null;

            do
            {

                Console.Write(message);
                input = Console.ReadLine();

            } while (!decimal.TryParse(input, out validatedDecimal));

            return validatedDecimal;

        }
        public static string CheckforBlank(string input)
        {
            string usersInput = input;
            while(string.IsNullOrWhiteSpace(usersInput))
            {
                Console.WriteLine("Please do not leave blank!");
                usersInput = Console.ReadLine();
            }

            return usersInput;
        }
    }
}

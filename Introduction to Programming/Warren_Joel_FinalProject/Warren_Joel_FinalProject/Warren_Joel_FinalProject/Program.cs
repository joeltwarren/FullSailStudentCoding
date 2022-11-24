using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {

            // welcome the user to the program
            Console.WriteLine("Welcome to the bill calculator!");
            Console.WriteLine("This program will be totaling up your bills for the any number of months you choose.");
            Console.WriteLine("\r\n");

            // collect data from the user
            Console.WriteLine("Please enter your list of monthly bills and press RETURN.");
            Console.WriteLine("Please use the following format Bill1, Bill2, Bill3, ...");

            // variable to store the users input as a string
            string stringOfBills = Console.ReadLine();

            // new line character
            Console.WriteLine("\r\n");

            // validation for blank
            while (string.IsNullOrWhiteSpace(stringOfBills)) {

                // code will run until user enters something
                Console.WriteLine("Please do not leave this blank and use the format Bill1, Bill2, Bill3, ...");

                // re-catch users input
                stringOfBills = Console.ReadLine();

                // new line character
                Console.WriteLine("\r\n");

                

            }

            //do a function call to the CreateBillArray
            string [] finalBillsArray = CreateBillArray(stringOfBills);
            
            //do a function call to billCosts Function
            decimal[] finalCostOfBills = BillCosts(finalBillsArray);

            //do a function call to TotalOfBills function
            decimal finalTotalCost = TotalOfBills(finalCostOfBills);
            
            // rounding the final cost to 2 decimal places and away from zero
            finalTotalCost = decimal.Round(finalTotalCost, 2, MidpointRounding.AwayFromZero);

            //new line
            Console.WriteLine("\r\n");

            // finish the output by asking the user how many months they want to know the total bills for
            Console.WriteLine("Please enter the number of months you would like to know your bills total for?");
            string numOfMonthsTotalString = Console.ReadLine();

            // create a int variable to hold the num of months
            int numOfMonthsTotal;

            //validate the users input for numbers only
            while (!int.TryParse(numOfMonthsTotalString, out numOfMonthsTotal)) {

                // will run until user enters a vaild number
                // notify the user
                Console.WriteLine("Please enter a vaild numeric number of months");

                // re-catch the users response
                numOfMonthsTotalString = Console.ReadLine();

            }

            // do the math
            decimal grandTotal = finalTotalCost * numOfMonthsTotal ;

            // round the grandtotal to two decimal places away from zero
            grandTotal = decimal.Round(grandTotal, 2, MidpointRounding.AwayFromZero);

            // outputting all totals to the console for the users final output
            Console.WriteLine("\r\n");
            Console.WriteLine("Your bills for 1 month come out to {0}.", finalTotalCost.ToString("C"));
            Console.WriteLine("\r\n");
            Console.WriteLine("For {0} months, you will owe {1}.", numOfMonthsTotal, grandTotal.ToString("C"));



            /* Testing Results
             * 
             * Input - Bill 1.Electric $85.00, Bill 2. Water $30.50, Bill 3. Gas $55.25 - Number of months - 6
             * Output "Your bills for 1 month come out to $170.75. For 6 months you will owe $1024.50."
             * 
             * Input - Bill 1. Cell Phone $100.00, Bill 2. Utilities $1500.79, Bill 3. Car Payment $481.67 - Number of months - 12
             * Output "Your bills for 1 month come out to $2,082.46. For 12 months, you will owe $24,989.52."
            */




        }

        // create my first method for utilizing the stringOfBills Variable to create an array of bills
        public static string [] CreateBillArray(string usersBills) {

            // create an array with a string split
            string[] arrayofBills = usersBills.Split(',');

            // trim the array after the split so that the strings will trim correctly
            // trim removes the beginning and end spaces of the whole string so i needed to split the string first
            for (int i = 0; i < arrayofBills.Length; i++) {
                arrayofBills[i] = arrayofBills[i].Trim();
            }

            return arrayofBills;
        }

        // create my second methood for collecting the users bill amounts
        public static decimal[] BillCosts(string [] bills) {

            // create a variable to hold the users input as a real number
            decimal convertedBillCost;

            //create the array to store the users bill costs 
            // creating the array as a null then determining the length using our parameter variables lenght and assigning it as a variable to the array size as an int.
            decimal[] billCosts = null; ;
            int arraySize = bills.Length;
            billCosts = new decimal[arraySize];
            

            // create a user prompt to ask for each bill cost
            for (int i = 0; i < bills.Length; i++) {
                Console.WriteLine("Please enter the cost of your {0} bill.", bills[i]);
                // catch the users input
               string usersBillCost = Console.ReadLine();

                // validate that the input is a number
                while (!decimal.TryParse(usersBillCost, out convertedBillCost)) {
                    //notify the users they did not enter a number
                    Console.WriteLine("Please enter a vaild number and do not leave blank.");
                    //re-catch the users input
                    usersBillCost = Console.ReadLine();

                }


                // set the billCosts array inside the for loop

                billCosts[i] = convertedBillCost;

                
            }

           // function return

            return billCosts;



        }

        // create the TotalOfBills function
        public static decimal TotalOfBills(decimal [] costs) {

            decimal totalOfBills = 0;

            for (int i = 0; i < costs.Length; i++) {
                totalOfBills += costs[i];
            }

            //return the total
            return totalOfBills;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problem #1 Space Cadet

            // welcome the user to the space program
            Console.WriteLine("Welcome to the Space Program Cadet!");
            Console.WriteLine("We are going to see what your weight is on the moon.\r\nPlease enter you weight in pounds and press the RETURN.");
            // declare a variable that will hold the users input
            string astronautsWeight = Console.ReadLine();
            // declare a variable that will hold the convereted weight
            double convertedAstronautWeight;
            // validate the users weight input and convert it to an interger
            while (!double.TryParse(astronautsWeight, out convertedAstronautWeight)) {
                // tell the user what went wrong
                // this code will loop until the user enters a correct weight
                Console.WriteLine("Please enter your numeric weight in pounds and do not leave blank, then press RETURN.");
                // recapture the users input
                astronautsWeight = Console.ReadLine();

            }

            // create a function and do a function call then post the information out for the user
            double moonweight = WeightConverter(convertedAstronautWeight);
            // rounding to 2nd decimal place away from zero so that the half way mark round up to the next number
            moonweight = Math.Round(moonweight, 2,MidpointRounding.AwayFromZero);
            // writing it out to the user
            Console.WriteLine("On Earth you weigh {0} lbs, but on the moon you would only weigh {1} lbs", convertedAstronautWeight, moonweight);

            /* Test Values for Space Cadet Weight
             * Input - weight 160
             * Result - “On	Earth you weigh 160 lbs, but on the	moon you would only weigh 26.67 lbs.”
             * 
             * Input - weight 210
             * Result - “On	Earth you weigh 210 lbs, but on the	moon you would only weigh 35 lbs.”
             * 
             * Input - One hundred pounds
             * Result - "Please enter your numeric weight in pounds and do not leave blank, then press RETURN."
             * 
             * Input - weight 100
             * Results - "On Earth you weigh 100 lbs, but on the moon you would only wiegh 16.67 lbs"
            */






            Console.WriteLine("\r\n Welcome to the Discount Calculator");
            // Problem # 2 Discount Calculator
            // ask the user for two prices and a discount rate
            Console.WriteLine("Please enter a cost for the 1st item.");

            // declare a variable to catch the users input
            string costItem1 = Console.ReadLine();
            // declare a variable to hold the converted number
            decimal convertedCostItem1;
            // validate the users input
            while (!decimal.TryParse(costItem1, out convertedCostItem1)) {
                // this code will run until the user enters a valid number
                // tell the user what is wrong
                Console.WriteLine("Please enter a valid numeric price and do not leave this blank, then hit RETURN.");
                // re-catch the users input
                costItem1 = Console.ReadLine();

            }
            // ask the user for the second item cost
            Console.WriteLine("Please enter a cost for the 2nd item.");

            // declare a variable to catch the users input
            string costItem2 = Console.ReadLine();
            // declare a variable to hold the converted number
            decimal convertedCostItem2;
            // validate the users input
            while (!decimal.TryParse(costItem2, out convertedCostItem2))
            {
                // this code will run until the user enters a valid number
                // tell the user what is wrong
                Console.WriteLine("Please enter a valid numeric price and do not leave this blank, then hit RETURN.");
                // re-catch the users input
                costItem2 = Console.ReadLine();

            }
            // ask the user for the discount amount
            Console.WriteLine("Please enter a discount to apply to the items.");

            // declare a variable to catch the users input
            string discount = Console.ReadLine();
            // declare a variable to hold the converted number
            decimal convertedDiscount;
            // validate the users input
            while (!decimal.TryParse(discount, out convertedDiscount))
            {
                // this code will run until the user enters a valid number
                // tell the user what is wrong
                Console.WriteLine("Please enter a valid numeric discount and do not leave this blank, then hit RETURN.");
                // re-catch the users input
                discount = Console.ReadLine();

            }
            // create a function and call it to give the user the input
            decimal finalDiscountedPrice = DiscountCalc(convertedCostItem1, convertedCostItem2, convertedDiscount);
            // do the math for rounding
            finalDiscountedPrice = Math.Round(finalDiscountedPrice, 2, MidpointRounding.AwayFromZero);
            // put the totals out for the user
            Console.WriteLine("With a {0}% discount your total is ${1}", convertedDiscount, finalDiscountedPrice);

            /* Discount Calculator Test Values
             * Input - Cost 1 - 10.00, Cost - 2 15.50, Discount - 20
             * Result - "With a 20% discount your total is $20.40"
             * 
             * Input - Cost 1 - 20.25, Cost 2 - 37.75, Discount - 10
             * Result - "With a 10% discount your total is $52.20"
             * 
             * Input - Cost 1 - 75.50, Cost 2 - 125.25, Discount - 25
             * Result - "With a 25% discount your total is $150.56"
            */

            Console.WriteLine("\r\n");




            // Problem # 3 Double the Fun
            // weclome the user
            Console.WriteLine("Welcome to Double the Fun!");
            Console.WriteLine("We are taking a set of hard coded arrays, and doubling them using a function.");
            // declare and define the array
            int[] arrayOfIntergers = new int[] {1,2,5,6,9};

            // comment out the above array and uncomment the below arrays to test the value changes
            // int[] arrayOfIntergers = new int[] {13,3,8,20,7};
            // int[] arrayOfIntergers = new int[] {10,20,30,40,50};

            // create the function to return the doubled value 
            // created the array to hold the return ArryDoubler function variables
            int[] doubledArrays = ArrayDoubler(arrayOfIntergers);
            
            
            Console.WriteLine("Your original array was [{0}, {1}, {2}, {3}, {4}] and now that it is doubled it is [{5}, {6}, {7}, {8}, {9}]", arrayOfIntergers[0], arrayOfIntergers[1], arrayOfIntergers[2], arrayOfIntergers[3], arrayOfIntergers[4],doubledArrays[0], doubledArrays[1], doubledArrays[2], doubledArrays[3], doubledArrays[4]);
            
            /* Test Values for Double the Fun
             * 
             * Initial Array - [1,2,4,6,9]
             * Results - Your original array was [1, 2, 4, 6, 9] and now that it is doubled it is [2, 4, 10, 12, 18]
             * 
             * Initial Array - [13,3,8,20,7]
             * Results - Your original array was [13, 3, 8, 20, 7] and now that it is doubled it is [24, 6, 16, 40, 14]
             * 
             * Initial Array - [10,20,30,40,50]
             * Results - Your original array was [10, 20, 30, 40, 50] and now that it is doubled it is [20, 40, 60, 80, 100]
            */
        }
        // Double the Fun Function
        public static int [] ArrayDoubler(int [] arrayToDouble) {
            // create a new array to hold the doubled values
            int[] doubleArray = new int[arrayToDouble.Length];
            // create a for loop to iterate through the array values and double each one
            for (int i = 0; i < arrayToDouble.Length; i++) {
                doubleArray[i] = arrayToDouble[i] * 2;
            }
            // return the doubleArray
            return doubleArray;

        }

        // Discount Calculator Function
        public static decimal DiscountCalc(decimal item1, decimal item2, decimal discount) {
            // convert the discount variable into a decimal for math percent purposes
            discount = discount / 100;
            // declare variables and do the math
            decimal discountAmount = (item1 + item2) * discount;
            decimal finalPrice = (item1 + item2) - discountAmount; 

            // return the final price
            return finalPrice;


        }


        // space cadet function
        public static double WeightConverter(double weight) {
            // create a variable and do the math
            double moonweight = weight / 6;

            // output the return
            return moonweight;


        }



    }
}

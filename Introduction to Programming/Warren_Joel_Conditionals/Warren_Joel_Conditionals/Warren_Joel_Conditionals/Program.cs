using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {

            // Problem #1 The Baking Converter



            // Welcome the user
            Console.WriteLine("Welcome to the Baking Converter!");

            // Create a variable to contain the weight amount
            double weight;

            // ask the user to enter a weight amount to be converted
            Console.WriteLine("Enter weight amount that you want converted and press RETURN");

            // capture the users input to a string variable
            string userEnteredWeight = Console.ReadLine();

            // while loop to perform validation (try parse is attempting to convert to a double now from the string userEnteredWeight)
            while (!double.TryParse(userEnteredWeight, out weight)) {
                // this code will run until the user enters a weight that can be converted to a double
                // tell the user the problem
                Console.WriteLine("Oops you did not enter a number to be converted please enter a numeric value and press RETURN.");
                
                // recapture the users input if it could not be validated
                userEnteredWeight = Console.ReadLine();

                // reparsing the usersEnteredWeight string
                double.TryParse(userEnteredWeight, out weight);

            }
            // Ask the user if they are converting from grams to ounces OR ounces to grams
            Console.WriteLine("Enter 'oz' for ounces or 'g' for grams of your weight and press RETURN.");

            // collect the users input in a string variable
            string unitOfMeasure = Console.ReadLine();

            // casting the string to lowercase
            unitOfMeasure = unitOfMeasure.ToLower();

            // declaring a bool variable to use in my while loop(I used this because I could not figure out how to do a while loop with three comparisions)
            bool correctUnitOfMeasure;

            // defining the bool variable
            if (unitOfMeasure == "g" | unitOfMeasure == "oz")
            {
                correctUnitOfMeasure = true;
            }
            else {
                correctUnitOfMeasure = false;
            }

            // creating a while loop to force correct validation to occur
            while (string.IsNullOrWhiteSpace(unitOfMeasure) | correctUnitOfMeasure != true) {
                
                // Executes this code until the user enters the correct valided text string of "g" or "oz"
                Console.WriteLine("Please do not leave this blank and enter either 'oz' for ounces or 'g' for grams and press RETURN");
               
                // recollect the users input and try again
                unitOfMeasure = Console.ReadLine();
                // forcing lowercase again
                unitOfMeasure = unitOfMeasure.ToLower();

                // reset the correctUnitOfMeasure bool Variable
                if (unitOfMeasure == "g" | unitOfMeasure == "oz")
                {
                    correctUnitOfMeasure = true;
                }
                else
                {
                    correctUnitOfMeasure = false;
                }
            }

            // creating a variable to hold the conversion data rates
            double conversionRate = 28.34952;
            // creating a variable to hold the actual converted weight
            double convertedWeight;

            // Doing the conversion from g to oz OR oz to g

            if (unitOfMeasure == "g") {
                // if the user entered g for a unit of measure we divide the weight by the conversion rate to get ounces
                convertedWeight = weight / conversionRate;

                // rounding to the 3rd digit
                convertedWeight = Math.Round(convertedWeight,3);

                // informing user of all related math information
                Console.WriteLine("Since you entered {0} {1}, your converted weight is {2} ounces. Rounded to the 3rd decimal place.", weight, unitOfMeasure, convertedWeight);

            } else if (unitOfMeasure == "oz") {
                // if the user entered oz for a unit of measure we multiply the weight by the conversion rate to get grams
                convertedWeight = weight * conversionRate;

                // rounding to the 3rd decimal place
                convertedWeight = Math.Round(convertedWeight, 3);

                // informing user of all related math information
                Console.WriteLine("Since you entered {0} {1}, your converted weight is {2} grams. Rounded to the 3rd decimal place.", weight, unitOfMeasure, convertedWeight);
            }
            else {
                // simply catching any type of failure to allow the code not to throw an exception and exit gracefully if nothing in the math works.
                Console.WriteLine("Something went wrong with the math Please try running the Application again!");

            }

            // testing during building
            /*
            Console.WriteLine("You entered a weight of {0} and it times 2 = " + weight * 2, weight);
            Console.WriteLine("You entered the unit of measure {0}", unitOfMeasure);
            Console.WriteLine("Currently the unit of measure is {0}", correctUnitOfMeasure);
            */


            /*Data Tests
             * Input - weight = 200 units = "g"
             * Output "Since you entered 200 g, your converted weight is 7.055 ounces. Rounded to the 3rd decimal place."
             * 
             * Input - weight = 12 units = "oz"
             * "Since you entered 12 oz, your converted weight is 340.194 grams. Rounded to the 3rd decimal place."
             * 
             * Input - weight = 50 units = "OZ"
             * "Since you entered 50 oz, your converted weight is 1417.476 grams. Rounded to the 3rd decimal place."
             * 
             * Input - weight = 500.50 units = "G"
             * "Since you entered 500.5 g, your converted weight is 17.655 ounces. Rounded to the 3rd decimal place."
            */

            // new line spacing between Problems
            Console.WriteLine("\r\n");




            // Problem # 2 Pizza Per Person

            // welcome the user to the new Application
            Console.WriteLine("Welcome to the Pizza Party Planner!\r\n");

            // Ask the user questions and start collecting data to store in variables
            Console.WriteLine("How many pizzas did you order?");

            // save the response
            string numPizzaOrdered = Console.ReadLine();

            // create variable to hold converted number in
            double convertedPizzaOrdered;

            // while loop validation for the number of pizza's ordered
            while (!double.TryParse(numPizzaOrdered, out convertedPizzaOrdered)) {
                // tell the user what went wrong
                Console.WriteLine("Please enter a number! and press RETURN");
               
                // catch the response
                numPizzaOrdered = Console.ReadLine();

            }

            // ask the next question
            Console.WriteLine("How many slices per pizza?");

            // save the response
            string numSlices = Console.ReadLine();

            // create variable to hold converted number in
            double convertedNumSlices;

            // while loop validation for the number of slices in each pizza
            while (!double.TryParse(numSlices, out convertedNumSlices))
            {
                // tell the user what went wrong
                Console.WriteLine("Please enter a number! and press RETURN");

                // catch the response
                numSlices = Console.ReadLine();
            }

            // ask the next question
            Console.WriteLine("How many guest will be at the party?");

            // save the response
            string numguests = Console.ReadLine();

            // create variable to hold converted number in
            double convertedNumGuests;

            // while loop validation for the number of Guests
            while (!double.TryParse(numguests, out convertedNumGuests))
            {
                // tell the user what went wrong
                Console.WriteLine("Please enter a number! and press RETURN");

                // catch the response
                numguests = Console.ReadLine();
            }

            // ask the next question
            Console.WriteLine("How many slices will each guest eat?");

            // save the response
            string numSlicesEach = Console.ReadLine();

            // create variable to hold converted number in
            double convertedNumSlicesEach;

            // while loop validation for the number of slices each quest will eat
            while (!double.TryParse(numSlicesEach, out convertedNumSlicesEach))
            {
                // tell the user what went wrong
                Console.WriteLine("Please enter a number! and press RETURN");

                // catch the response
                numSlicesEach = Console.ReadLine();
            }

            // time to do the math
            // creating a variable for total number of slices on hand
            double grandTotalSlicesOnHand;
            grandTotalSlicesOnHand = convertedPizzaOrdered * convertedNumSlices;

            // creating a variable for total number of slices needed
            double grandTotalSlicesNeeded;
            grandTotalSlicesNeeded = convertedNumGuests * convertedNumSlicesEach;

            // Creating an if statement to finish the math comparision
            if (grandTotalSlicesOnHand >= grandTotalSlicesNeeded)
            {
                // Tell the user whats going on
                Console.WriteLine("Yes, you have enough pizza for you guests with " + (grandTotalSlicesOnHand - grandTotalSlicesNeeded) + " slices left over.");

            }
            else {
                // Tell the user whats going on
                Console.WriteLine("You need at least " + (grandTotalSlicesNeeded - grandTotalSlicesOnHand) + " more slices of pizza. You should order more pizza.");

            }



            // testing during coding making sure the math works on the converted numbers
            /*
            Console.WriteLine(convertedPizzaOrdered *2 +" Is double the number of Pizza's Ordered");
            Console.WriteLine(convertedNumSlices * 2 + " Is double the number of Slices");
            Console.WriteLine(convertedNumGuests * 2 + " Is double the number of Guests");
            Console.WriteLine(convertedNumSlicesEach * 2 + " Is double the number of slices each guest eats");
            Console.WriteLine(grandTotalSlicesOnHand);
            Console.WriteLine(grandTotalSlicesNeeded);
            */

            /*TEST RESULTS
             * 
             * 
             * Input - Pizzas: 10, Slices per Pizza: 8, Guest Count:11, Slices per Guest: 5
             * Result - "Yes, you have enough pizza for your guests with 25 slices left over."
             * 
             * Input - PIzzas: 5, Slices per Pizza: 6, Guest Count: 8, Slices per Guest: 5
             * Result - "You need at least 10 more slices of pizza. You should order more pizza."
             * 
             * Input - PIzzas: 12, Slices per pizza: 10, Guest 25, Slices per Guest 2
             * Result - "Yes, you have enough pizza for your guests with 70 slices left over."
             * 
            */

            //New line for program seperation
            Console.WriteLine("\r\n");




            // Problem #3 Tax Brackets

            // welcome the user to the program
            Console.WriteLine("Welcome to the tax bracket locator");

            //Going ahead and creating arrays to hold the table data
            int[] tier = new int[] {1, 2, 3, 4, 5, 6, 7 };
            double[] taxRate = new double[] {10, 15, 25, 28, 33, 35, 39.6 };
            decimal[] incomeBracket = new decimal[] {9000M, 37950M, 91900M, 191650M, 416700M, 418400M, 418400M};

            // ask the user for the income level
            Console.WriteLine("Please enter your income (in $) and press RETURN");

            // save the response
            string userIncome = Console.ReadLine();

            // creating a variable to hold the converted user income in decimal form
            decimal convertedUserIncome;

            // create a while loop for validation
            while (!decimal.TryParse(userIncome, out convertedUserIncome)) {
                // code will execute until user enters a valid Income
                // alert the user of whats going on
                Console.WriteLine("Please enter a valid numeric income in $ and press RETURN");

                // catch the response
                userIncome = Console.ReadLine();

            }

            // Time to figure out which brackets are what and write it out to the screen
            // Creating a variable to hold the count across all arrays
            int indexNumber;

            // using an if statement to test the income brackets because they change from up to TO up to but not including
            if (convertedUserIncome <= incomeBracket[0])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 0;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);

            }
            else if (convertedUserIncome < incomeBracket[1])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 1;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);

            }
            else if (convertedUserIncome < incomeBracket[2])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 2;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);
            }
            else if (convertedUserIncome < incomeBracket[3])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 3;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);
            }
            else if (convertedUserIncome < incomeBracket[4])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 4;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);
            }
            else if (convertedUserIncome < incomeBracket[5])
            {
                // setting the indexNumber = to the income Bracket index count
                indexNumber = 5;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);
            }
            else
            {
                // setting the indexNumber = to the last income Bracket index count
                indexNumber = 6;
                // writing out to the user where they are on the tax table
                Console.WriteLine("You have an income of ${0} which puts you in tier {1} and your tax rate is {2}%.", convertedUserIncome, tier[indexNumber], taxRate[indexNumber]);
            }

            /* Test Results
             * 
             * Income - $63234
             * Result "You have an income of $63234 which puts you in tier 3 and your tax rate is 25%."
             * 
             * Income - $200000
             * Result "You have an income of $200000 which puts you in tier 5 and your tax rate is 33%."
             * 
             * Income - $500000
             * Result "You have an income of $500000 which puts you in tier 7 and your tax rate is 39.6%."
             * 
             * Income - $416700
             * Result "You have an income of $416700 which puts you in tier 6 and your tax rate is 35%."
             */

            //new line char to seperate applications
            Console.WriteLine("\r\n");


            // Problem #4 Discount Calculator
            // welcome the user to the new application
            Console.WriteLine("Welcome to Discount Double Check, let's see if we can get you a discount!"+ "\r\n");

            // ask for the price of the first item
            Console.WriteLine("Please enter the cost of your first item in $ and press RETURN.");

            // save the answer to question 
            string firstItemPrice = Console.ReadLine();

            //create a variable to store the decimal conversion to
            decimal convertedFirstItemPrice;

            // validate the string to be a number with a while loop
            while (!decimal.TryParse(firstItemPrice, out convertedFirstItemPrice)) {
                // code will run unitl the user gives us an input that will convert to a decimal
                // inform the user of whats wrong
                Console.WriteLine("Please enter a valid number and press RETURN!");

                // catch the response
                firstItemPrice = Console.ReadLine();

            }

            // ask for the price of the second item
            Console.WriteLine("Please enter the cost of you second item in $ and press RETURN.");

            // save the answer to question
            string secondItemPrice = Console.ReadLine();

            // create a variable to store the decimal conversion to
            decimal convertedSecondItemPrice;

            // validate the string to be a number with a while loop
            while (!decimal.TryParse(secondItemPrice, out convertedSecondItemPrice)) {
                // code will run until the user gives us an input that will convert to a decimal
                // inform the user of whats wrong
                Console.WriteLine("Please enter the a valid number and press RETURN!");

                // catch the response
                secondItemPrice = Console.ReadLine();

            }
            // Total the values of items purchased to determine discounts
            decimal totalPriceTogether = convertedFirstItemPrice + convertedSecondItemPrice;

            // known variables for discounts
            decimal discountFive = 5;
            decimal discountTen = 10;

            // create variables to store the discounts
            
            decimal discount5 = discountFive / 100;
            decimal discount10 = discountTen / 100;

            // create a grandtotal variable including discounts if they apply
            decimal grandTotal;

            // if statement to determine when to apply discounts
            if (totalPriceTogether < 50)
            {
                // set grand total with no discount
                grandTotal = totalPriceTogether;
                // rounding the grand total to 2 digits
                grandTotal = Math.Round(grandTotal, 2, MidpointRounding.AwayFromZero);

                // tell the user what the cost is
                Console.WriteLine("Your total purchase is ${0}.", grandTotal);

            }
            else if (totalPriceTogether >= 50 && totalPriceTogether < 100)
            {
                // set grand total with a 5% discount
                grandTotal = totalPriceTogether - (discount5 * totalPriceTogether);
                // rounding the grand total to 2 digits
                grandTotal = Math.Round(grandTotal, 2, MidpointRounding.AwayFromZero);

                // tell the user what the cost is
                Console.WriteLine("Your total purchase is ${0}, which includes your {1}% discount", grandTotal, discountFive);
            }
            else {
                // set grand total with a 10% discount
                grandTotal = totalPriceTogether - (discount10 * totalPriceTogether);
                // rounding the grand total to 2 digits
                grandTotal = Math.Round(grandTotal, 2, MidpointRounding.AwayFromZero);

                // tell the user what the cost is
                Console.WriteLine("Your total purchase is ${0}, which includes your {1}% discount", grandTotal, discountTen);

            }

            /*
             * Test Results
             * Input - First Item Cost - $45.50, Second Item Cost - $75.00, Total $108.45
             * Result - "Your total purchase is $108.45, which includes 10% discount."
             * 
             * Input - First Item Cost - $30.00, Second Item Cost - $25.00, Total - $52.25
             * Result - "Your total purchase is $53.25, which includes your 5% discount."
             * 
             * Input - First Item Cost - $5.75, Second Item Cost - $12.50 - Total $18.25
             * Result - "Your total purchase is $18.25."
             * 
             * Input - First Item Cost - $150.00, Second Item Cost - $200.00 - Total $315.00
             * Result - "Your total purchase is $315.00, which includes your 10% discount"
             * 
            */
        }
    }
}

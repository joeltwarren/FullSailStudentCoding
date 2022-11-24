using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_LogicLoops
{
    class Program
    {
        static void Main(string[] args)
        {

            // Problem #1: Making the Grade

            // declaring a new array
            int[] grades = new int[2];

            // Welcome the user to the application
            Console.WriteLine("Welcome to making the Grade \r\n");

            // ask the user for the frist grade
            Console.WriteLine("Please enter your first grade, then hit RETURN");
            // declare a variable to store the value and read the console
            string gradeOne = Console.ReadLine();

            // while loop for validation
            while (!int.TryParse(gradeOne, out grades [0])) {
                // this will run until the user gives us a valid number
                // inform the user of whats happening
                Console.WriteLine("Please enter a numeric value and press RETURN.");

                // store the response
                gradeOne = Console.ReadLine();
            }

            // ask the user for the second grade
            Console.WriteLine("Please enter your second grade, then hit RETURN");
            // declare a variable to store the value and read the console
            string gradeTwo = Console.ReadLine();

            // while loop for validation and array creation
            while (!int.TryParse(gradeTwo, out grades [1])) {
                // this will run until the user gives us a valid number
                // inform the user of whats happening
                Console.WriteLine("Please enter a numeric value and press RETURN.");

                // store the response
                gradeTwo = Console.ReadLine();
            }

            // setting up the single conditional IF statement to check that both grades are above 70
            if (grades[0] >= 70 && grades[1] >= 70)
            {
                // Since both grades are above passing congratulate the user
                Console.WriteLine("Congrats, both grades are passing!");
            }
            else {
                // Since one or more grades are failing notify the user
                Console.WriteLine("One or more grades are failing, try harder next time!");

            }
            /*
             * Data Test
             * Input - Grade 1 - 95, Grade 2 - 85
             * Result - "Congrats, both grades are passing!"
             * 
             * Input - Grade 1 - 82, Grade 2 - 68
             * Result - "One or more grades are failing, try harder next time!"
             * 
             * Input - Grade 1 - Eighty Computer re-prompted, Grade 1 - 80, Grade 2 - 91
             * Result - "Congrats, both grades are passing!"
             * 
             * Input - Grade 1 - 69, Grade 2 - 70
             * Result - "One or more grades are failing, try harder next time!"
             *             
            */



            // new line char for next program
            Console.WriteLine("\r\n");

            // Problem #2 - Logical Operators: Brunch Bunch

            // welcome the user to the program
            Console.WriteLine("Welcome to the Brunch Bunch");

            // declare a variable to hold the converted age
            int convertedAge;
            // declare other know variables money is deciamls
            decimal reducedBrunch = 10.00M;
            decimal normalBrunch = 15.00M;

            // request the users age
            Console.WriteLine("Please enter your age and then press RETURN.");

            // catch the users response
            string usersAge = Console.ReadLine();

            // while loop for testing that we have a valid numeric input
            while (!int.TryParse(usersAge, out convertedAge)) {
                // this code will run unitll the user gives us a vaild numeric age
                // inform the user of whats going on
                Console.WriteLine("Please enter a valid numeric age and press RETURN.");

                // re-capture the users input
                usersAge = Console.ReadLine();

            }

            // line space char
            Console.WriteLine("\r\n");
            
            // now that we have a proper converted age we can create our if statement
            if (convertedAge < 10 || convertedAge >= 55)
            {
                // tell the user that they get the discounted brunch
                Console.WriteLine("Your cost for brunch today is ${0}", reducedBrunch);
            }
            else {
                // tell the user they pay the normal price
                Console.WriteLine("Your cost for brunch today is ${0}", normalBrunch);
            }
            /*
             * Test Values
             * Age	– 57	Results	– “Your	cost for brunch	today is $10.00”
             * Age	– 39	Results	– “Your	cost for brunch	today is $15.00”
             * Age	– 8		Results	– “Your	cost for brunch	today is $10.00”
             * Age	– 10    Results	– “Your	cost for brunch	today is $15.00”
             * Age  - 80    Results - "Your cost for brunch today is $10.00"
            */

            // new line char for new app
            Console.WriteLine("\r\n");

            Console.WriteLine("Welcome to the Add Them Up Movie Counter");

            // Problem #3 - For Loop: Add them Up

            // declare the array to hold the converted user inputs
            int[] numMovies = new int[3];

            // ask the user for the amount of DVDs they own
            Console.WriteLine("Please enter the number of DVD's you own and press RETURN.");

            // catch the users response
            string numDvds = Console.ReadLine();

            // validate using the while loop and tryparse
            while (!int.TryParse(numDvds, out numMovies[0])) {
                // this code will run until the user gives us a valid numeric input
                // inform the user of whats going on
                Console.WriteLine("Please enter a numeric value of the number of DVD's you own and press RETURN.");

                // catch the users response again
                numDvds = Console.ReadLine();
            }
            // ask the user for the amount of Blu-Rays they own
            Console.WriteLine("Please enter the number of Blu-Rays you own and press RETURN.");

            // catch the users response
            string numBlurays = Console.ReadLine();

            // validate using the while loop and tryparse
            while (!int.TryParse(numBlurays, out numMovies[1]))
            {
                // this code will run until the user gives us a valid numeric input
                // inform the user of whats going on
                Console.WriteLine("Please enter a numeric value of the number of Blu-Rays you own and press RETURN.");

                // catch the users response again
                numBlurays = Console.ReadLine();
            }
            // ask the user for the amount of UltraViolets they own
            Console.WriteLine("Please enter the number of UltraViolets you own and press RETURN.");

            // catch the users response
            string numUltraviolets = Console.ReadLine();

            // validate using the while loop and tryparse
            while (!int.TryParse(numUltraviolets, out numMovies[2]))
            {
                // this code will run until the user gives us a valid numeric input
                // inform the user of whats going on
                Console.WriteLine("Please enter a numeric value of the number of UltraViolets you own and press RETURN.");

                // catch the users response again
                numUltraviolets = Console.ReadLine();
            }


            // determine the number of indicies that are in the array for use in the math and store it
            int indexTotal = numMovies.Length;

            // used this code to visually test the total number of index in the array
            //Console.WriteLine(indexTotal);

            // create a grand total variable to hold all the totals of the array
            int grandTotal = 0;

            // Now that we have all the validated user input we can do the math
            
            for (int i = 0; i < indexTotal; i++) {
                grandTotal += numMovies[i];
                // used this to visually verify the math worked
                //Console.WriteLine(grandTotal);
            }

            // Now that the math is done we can create an if statement to determine which feedback to give the user
            if (grandTotal >= 100)
            {
                // tell the user your impressed
                Console.WriteLine("Wow, I am impressed with your collection of {0} movies!", grandTotal);
            }
            else {
                // tell the user their total movies
                Console.WriteLine("You have a total of {0} movies in your collection.", grandTotal);
            }
            /*
             * Test Values
             * 
             * Input - DVDs - 45, Blu-Rays - 15, UltraViolets - 2
             * Result - "You have a total of 62 movies in your collection."
             * 
             * Input - DVDs - 60, Blu-Rays - 75, UltraViolets - 45
             * Result - "Wow, I am impressed with your collection of 180 movies."
             * 
             * Input - DVDs - 25, Blu-Rays - 50, UltraViolets - 75
             * Result - "Wow, I am impressed with your collection of 150 movies."
            */


            // New line char
            Console.WriteLine("\r\n");

            // Problem #4 - While Loop: Cha-Ching!

            // welcome the user to the new app
            Console.WriteLine("Welcome to Cha-Ching!");

            // create a decimal variable to store the converted card balance to
            decimal giftCardTotal;
            // create a decimal variable to store the users amount of purchases during the validation using the nested while loop
            decimal giftCardDeduction;

            // ask the user for the card balance
            Console.WriteLine("Please enter your gift card amount.");

            // catch the users response
            string usersGiftCardTotal = Console.ReadLine();

            // while loop to validate that the user entered a valid numeric input
            while (!decimal.TryParse(usersGiftCardTotal, out giftCardTotal)) {
                // this will run unitl the user gives us a valid numeric input
                // tell the user what is going on
                Console.WriteLine("Please enter a valid numeric input and press RETURN.");

                // catch the response
                usersGiftCardTotal = Console.ReadLine();

            }
            // now that we have the users gift card total converted to a decimal that we can work with
            // we can now create our while loop to deduct the balance from the card
            while (giftCardTotal > 0) {
                // we are going to ask the user how much their purchases are and deduct that from the giftcard totals
                Console.WriteLine("How much is your purchase?");
                // catch the users response and validate it
                while (!decimal.TryParse(Console.ReadLine(), out giftCardDeduction))
                {
                    // this code will run until the user gives the a vaild numeric input
                    // inform the user of whats going on
                    Console.WriteLine("Please enter a valid numeric price in $ and press RETURN");
                }
                // once we have a valid numerical value to deduct from the giftcard total we can do the math
                giftCardTotal -= giftCardDeduction;

                // Now we are going to do a nested if statement to determine which feed back the user needs.
                // We tell the user how much money they have left to spend after their last purchase or what they owe.
                if (giftCardTotal > 0)
                {
                    Console.WriteLine("With Your current purchase of ${0}, you can still spend ${1}", giftCardDeduction, giftCardTotal);
                }
                else {
                    Console.WriteLine("With your last purchase of ${0}, you have used your giftcard up and still owe ${1}", giftCardDeduction, (giftCardTotal * (-1)));
                }

                /*
                 * Test Values
                 * Gift Card Amount - 30.00
                 * Purchase 1  - 5.00
                 * Result - "With your current purchase of $5.00, you can still Spend $25.00"
                 * Purchase 2 - 10.50
                 * Result - "With your current purchase of $10.50, you can still Spend $14.50"
                 * Purchase 3 - 16.00
                 * Result - "With your last purchase of $16.00, you have used your gift card up and still owe $1.50."
                 * 
                 * Gift Card Amount - 100.00
                 * Purchase 1 - 25.00
                 * Result - "With your current purchase of $25.00, you can still Spend $75.00"
                 * Purchase 2 - 50.00
                 * Result - "With your current purchase of $50.00, you can still Spend $25.00"
                 * Purchase 3 - 75.00
                 * Result - "With your last purchase of $75.00, you have used your gift card up and still owe $50.00."
                 
             
                */



            }

        }
    }
}

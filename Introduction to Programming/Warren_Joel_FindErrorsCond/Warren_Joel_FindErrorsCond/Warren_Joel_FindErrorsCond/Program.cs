using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_FindErrorsCondLoops.zip
{
    class Program
    {
        static void Main(string[] args)
        {

            /* INSTRUCTIONS
             *  1. Copy this code to a new project, do not work in this file!
             *  2. Start by finding and fixing all of the Syntax Errors first.
             *     - Syntax errors are the red squiggy lines that will prevent the code from running.
             *  3. Now the code should run and you can see the output on the console.
             *  4. Find the Logical Errors
             *     - Logical errors will give you the wrong output.
             *     - These are a bit harder to find.  Keep checking the correct output given!
             *     - Follow any additional instructions given in the comments.
             *  5. Once you think you are done, check your output line by line against the 
             *     given correct output.
             *  6. If it matches perfectly, zip your whole project file and submit it to FSO.
             * */

            //  NAME:  Enter your name
            //  DATE:  Enter the current date
            //  SDI Section #00
            //  Find and fix the errors

            //Name the program
            Console.WriteLine("Hello and welcome to the calorie counter!");

            //Ask the user their name and store the result in a variable
            Console.WriteLine("Please enter your name and press enter:");
            string userName = Console.ReadLine();

            //Validate the user prompted name is not left blank
            while (string.IsNullOrWhiteSpace(userName))
            {
                //This should run if the user leaves it blank or empty spaces

                //Alert the user to the problem
                Console.WriteLine("I am sorry but you can't leave this blank.");

                //Re-ask the user the questions
                Console.WriteLine("Please type in your name and press enter!");

                //Re-Catch the user's response
                userName = Console.ReadLine();


            }

            //Welcome the user
            Console.WriteLine("Thank you " + userName + "! \r\nWe will now cycle through your last 7 days of calories that you have eaten in a day.");
            //Explain the outcome of the program
            Console.WriteLine("\r\nWe will tell you if you are above, below or meet your daily limit and at the end you will also get the grand total of calories for the week.\r\n");


            //Create the array to hold the calories
            double[] calorieArray = new double[] { 2150, 1507.50, 3600, 2300, 2800, 2345, 3456 };

            //Create a variable to hold the users optimal daily calorie intake
            double targetDailyCalories = 2800;

            //Create a variable to hold the users optimal weekly calorie intake
            double targetWeeklyCalories = 7 * targetDailyCalories;

            //Create a counter that will hold the total of calories
            double totalCalories = 0;

            //This is a for loop that will cycle through the calories and add them up.
            for (int i = 0; i < calorieArray.Length; i++)
            {

                //Test each array element to see if it is over the daily limit
                if (calorieArray[i] > targetDailyCalories)
                {
                    double amountOver = calorieArray[i] - targetDailyCalories;
                    Console.WriteLine("On Day #" + (i + 1) + " you ate " + calorieArray[i] + " calories and have exceeded your daily limit by " + amountOver + " calories.");


                }
                else if (calorieArray[i] == targetDailyCalories)
                {

                    Console.WriteLine("On Day #" + (i + 1) + " you ate " + calorieArray[i] + " calories which is exactly your daily limit!");

                }
                else
                {
                    double amountUnder = targetDailyCalories - calorieArray[i];
                    Console.WriteLine("On Day #" + (i + 1) + " you ate " + calorieArray[i] + " calories and have are under your daily limit by " + amountUnder + " calories.");

                }


                //Add the calories to the total variable
                totalCalories += calorieArray[i];


            }






            Console.WriteLine("\r\nYour grand total of calories for the week is " + totalCalories + ".\r\n");


            //Find the difference for the weekly goal
            double weeklyDifference = targetWeeklyCalories -= totalCalories;


            //Determine if the weekly difference is above, meets or below
            if (weeklyDifference > 0)
            {
                //Report to the user
                Console.WriteLine("Congratulation! You are under " + weeklyDifference + " calories under your weekly limit!");


            }
            else if (weeklyDifference == 0)
            {
                //Report to the user
                Console.WriteLine("Congratulation! You have exactly met your ideal calories for the week!");

            }
            else
            {

                //Report to the user
                Console.WriteLine("Unfortunately you are over " + weeklyDifference + " calories for your weekly limit!");

            }
        }
    }
}

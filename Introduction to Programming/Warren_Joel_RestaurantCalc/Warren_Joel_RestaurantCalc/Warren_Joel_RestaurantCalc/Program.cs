using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_RestaurantCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * Joel Warren
             * C201804 01
             * 3/29/2018
             * Restaurant Tip Calculator
             * 
             */
            // Simply requesting users name and forcing a new line character and using concatenation
            Console.WriteLine("Tip Calculator App \r\n" + "\r\n" + "Hello please enter your First Name and press return");

            // Using Console.ReadLine(); to capture the users first name and store it in a variable firstName as a string
            string firstName = Console.ReadLine();

            // Outputting to the Console with a Concatenated String including users name variable and a general comment
            Console.WriteLine("\r\n" + "I hope you enjoyed your meal today" + " " + firstName);

            // Create an array to capture all three Check amounts first
            // Create an array to capture all the tip percentages as well
            // NOTE - I could have simply did a Console.ReadLine(); request of each check and tips stored it in a local variable
            // HOWEVER I wanted to see if I could convert the Strings to decimals using the array instead
            // I will use some "regular variables" later just to show I know how
            // Declaring an array called checks of the type string and setting its size to 3 
            string[] checks = new string[3];

            // Declaring an array called tips of the type string and setting its size to 3
            string[] tips = new string[3];

            // asking the user for the first meal price and storing the input in the checks array at index 0
            Console.WriteLine("\r\n" + "Please enter the total price for the first meal and press return");
            checks[0] = Console.ReadLine();

            // asking the user for the amount of the first tip they want to use and storing it in the array tips at index 0
            Console.WriteLine("\r\n" + "Please enter the total percentage you would like for the first meals tip and press return");
            tips[0] = Console.ReadLine();

            // asking the user for the amount of the second meal price and storing the input in the checks array at index 1
            Console.WriteLine("\r\n" + "Please enter the total price for the second meal and press return");
            checks[1] = Console.ReadLine();

            // asking the user for the amount of the second tip they want to use and storing it in the array tips at index 1
            Console.WriteLine("\r\n" + "Please enter the total percentage you would like for the second meals tip and press return");
            tips[1] = Console.ReadLine();

            // asking the user for the amount of the third meal price and storing the input in the checks array at index 2
            Console.WriteLine("\r\n" + "Please enter the total price for the third meal and press return");
            checks[2] = Console.ReadLine();

            // asking the user for the amount of the third tip they want to use and storing it in the array tips at index 2
            Console.WriteLine("\r\n" + "Please enter the total percentage you would like for the third meals tip and press return");
            tips[2] = Console.ReadLine();

            // Time to do some DataType conversions before the math
            // Declared an array of type decimal for the checks conversion
            decimal[] convertedChecks;

            // Defined array by using dot syntax to convert the checks "string" array to the convertedChecks "decimal" array
            convertedChecks = Array.ConvertAll<string, decimal>(checks, Convert.ToDecimal);

            // Declared and Defined the variable grandTotal which is the total of all meal costs and did the math
            decimal grandTotal = convertedChecks[0] + convertedChecks[1] + convertedChecks[2];

            // Declared an array of type decimal for the tips conversion
            decimal[] convertedTips;

            // Defined array by using dot syntax to convert the tips "string" array to the convertedTips "decimal" array
            convertedTips = Array.ConvertAll<string, decimal>(tips, Convert.ToDecimal);

            //Declared 3 Variables without defining them for calculating Tip amounts (I used regular variables here to follow guidelines)
            decimal check1Tip;
            decimal check2Tip;
            decimal check3Tip;

            // Math to Determine the amounts of the tips for each Check *NOTE* placed the () around the multiplication to avoid 0 calculations
            check1Tip = (convertedChecks[0] * convertedTips[0]) / 100;
            check2Tip = (convertedChecks[1] * convertedTips[1]) / 100;
            check3Tip = (convertedChecks[2] * convertedTips[2]) / 100;

            // Time to round to the 2nd decimal place with a midpoint round of up to the next digit away from zero.
            // simply redefining the tip variables with the new rounded values
            check1Tip = Math.Round(check1Tip, 2, MidpointRounding.AwayFromZero);
            check2Tip = Math.Round(check2Tip, 2, MidpointRounding.AwayFromZero);
            check3Tip = Math.Round(check3Tip, 2, MidpointRounding.AwayFromZero);

            // Declaring some variables for remaining totals
            decimal waitersTip;
            decimal grandTotalWithTips;
            decimal costPerPerson;

            // Now we simply Define our Variables while doing the math
            waitersTip = check1Tip + check2Tip + check3Tip;
            grandTotalWithTips = grandTotal + waitersTip;
            costPerPerson = grandTotalWithTips / 3;

            // rounding costperperson to 2 decimal places as well
            // additional note here is even with rounding this way some of the math ends up pennys off if you get to doing 7.5% tips but,
            // I could not figure out how to fix this without doing some floor or ceiling math and even then either the business makes a few cents extra or loses a few cents on a 3 way splitt
            costPerPerson = Math.Round(costPerPerson, 2, MidpointRounding.AwayFromZero);

            // Now we write out our values to the console for the user *NOTE* I was unable to use formattinging in the Console.WriteLine(); to force 2 decimals to show on the math instead of 56 showing 56.00
            // I tried a lot of ways but I am not sure if i had enough parenthesis but this would not work   + (checks[0].ToString("C"))    in the first meal line recplacing + checks[0]
            // writing out a new return
            Console.WriteLine("\r\n");
            // writing out the cost of the first meal + its tip percentage + its math calculated total + a new line 
            Console.WriteLine("Your first meal cost $" + checks[0] + " and its tip of "+ convertedTips[0] +"% was $" + check1Tip + " ,for a total of $"+(convertedChecks[0] + check1Tip)+ "\r\n" );
            // writing out the cost of the second meal + its tip percentage + its math calculated total + a new line
            Console.WriteLine("Your second meal cost $" + checks[1] + " and its tip of " + convertedTips[1] + "% was $" + check2Tip + " ,for a total of $" + (convertedChecks[1] + check2Tip) + "\r\n");
            // writing out the cost of the third meal + its tip percentage + its math calculated total + a new line
            Console.WriteLine("Your third meal cost $" + checks[2] + " and its tip of " + convertedTips[2] + "% was $" + check3Tip + " ,for a total of $" + (convertedChecks[2] + check3Tip) + "\r\n");
            // writing out the total off all meals without tips + a new line
            Console.WriteLine("The total for all your meals were $" + grandTotal + " without tips included" + "\r\n");
            // writing out the waiters tip and saying thank you to the user + a new line
            Console.WriteLine("Your waiter will recieve $" + waitersTip + " Thank you for your generosity " + firstName + "\r\n");
            // writing out the grand total for one person to pay including tips + a new line
            Console.WriteLine("The total bill for today including tips for one person to pay would be $" + grandTotalWithTips + "\r\n");
            // writing out the 3 way split of the bill rounded already + a new line
            Console.WriteLine("To split the bill three ways each person would pay $" + costPerPerson + "\r\n");
            // offering to let the user add $1 to the bill for the boys and girls club its just something I am accustomed to seeing
            Console.WriteLine("If you would like to donate $1 to the boys and girls club, please do so your new total would be $" + (grandTotalWithTips+=1) + "\r\n");

            /* <- Remove this comment and its correspoding end comment to see all the live test data
            // Live Testing Code a Simple Console.WriteLine(); with concatenated results for each variable as I added them                                                                                                                                               

            Console.WriteLine("\r\n"+ "Users Name = " + firstName);
            Console.WriteLine("Meal 1 total was $" + checks[0] +"\r\n" + "Meal 2 total was $" + checks[1] + "\r\n" +"Meal 3 total was $"+ checks[2] +"\r\n");
            Console.WriteLine("Tip 1 percentage was "+ tips[0] +"%\r\n" + "Tip 2 percentage was " + tips[1] + "%\r\n" + "Tip 3 percentage was "+ tips[2] +"%\r\n");
            Console.WriteLine("Array convertedChecks : ");
            Console.WriteLine("[{0}]", string.Join(",", convertedChecks));
            Console.WriteLine("Array convertedTips : ");
            Console.WriteLine("Did the Conversion work? " + "Yes if this line of code does not error out Grand Total of Meals was "+"$" +grandTotal);
            Console.WriteLine("[{0}]", string.Join(",", convertedTips));
            // Testing the math on convertedTips Array and Writing it to the console
            convertedTips[0] += 10;
            Console.WriteLine("This is correct if This answer of Tip percentage 1 + 10 = " +convertedTips[0] + "%");
            Console.WriteLine("Tip for meal 1 was rounded to $"+check1Tip +"\r\n" + "Tip for meal 2 was rounded to $" +check2Tip +"\r\n" +"Tip for meal 3 was rounded to $"+check3Tip
             */
            Console.WriteLine("Thank You for using the tip calculator written by Joel Warren using Arrays");

            /* Test Values
             * 
             * Test #1
             * Inputs
             * Check #1 - 10.00 Tip% - 15
             * Check #2 - 15.00 Tip% - 15
             * Check #3 - 25.00 Tip% - 20
             * 
             * Results
             * Total for Check#1 - $11.50
             * Total for Check#2 - $17.25
             * Total for Check#3 - $30.00
             * Total Tip for the Waiter - $8.75
             * Grand Total with Tips - $58.75
             * Cost per person if split evenly 3 ways - $19.58 Rounded
             * 
             * 
             * Test#2
             * Inputs
             * Check#1 - 24.50 Tip% - 15
             * Check#2 - 17.25 Tip% - 25
             * Check#3 - 31.00 Tip% - 20
             * 
             * Results
             * Total for Check#1 - $28.18 Rounded
             * Total for Check#2 - $21.56 Rounded
             * Total for Check#3 - $37.20
             * Total Tip for the Waiter - $14.19 Rounded
             * Grand Total with Tips - $86.94 Rounded
             * Cost per person if split evenly 3 ways - $28.98 Rounded
             * 
             * * Test#3 ( my own Test numbers )
             * Inputs
             * Check#1 - 32.83 Tip% - 12
             * Check#2 - 27.49 Tip% - 11
             * Check#3 - 17.86 Tip% - 10
             * 
             * Results
             * Total for Check#1 - $36.77 Rounded
             * Total for Check#2 - $30.51 Rounded
             * Total for Check#3 - $19.65 Rounded
             * Total Tip for the Waiter - $8.75 Rounded
             * Grand Total with Tips - $86.93
             * Cost per person if split evenly 3 ways - $28.98 Rounded
            */
        }
    }
}

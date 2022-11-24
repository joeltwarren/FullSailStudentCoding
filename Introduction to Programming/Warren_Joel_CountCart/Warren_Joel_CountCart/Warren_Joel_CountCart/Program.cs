using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_CountCart
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Joel Warren
             * 4/15/2018
             * Count Cart Assignment
             * C201804 01
            */

            // welcome the user to the program
            Console.WriteLine("Welcome to the Count Cart Program");

            // declare and define our hard coded array
            string[] items = new string[] { "snack", "drink", "vegetable", "drink", "meat", "snack", "vegetable", "snack", "drink", "drink", };

            
            // declare a count variable to keep up with how many items of each type were found in the array
            int itemCount = 0;
            
            // declaring a variable to store the users selection
            int itemSelection;
            
            // declare and define an array of valid seclitions for the menu to simplify the while loop
            int[] validSelection = new int[] { 1, 2, 3, 4 };

            // declare and define an array of chosenItems from the menu for use with my loop through the items array
            string[] chosenItem = new string[] { "snack", "drink", "vegetable", "meat"};

            // create the interface menu and get ready to collect the user input
            Console.WriteLine("------ MENU ------");
            Console.WriteLine("Please choose an item to add to the cart and press RETURN:");
            Console.WriteLine("(1) SNACKS" + "\r\n" + "(2) DRINKS" + "\r\n" + "(3) VEGETABLES" + "\r\n" + "(4) MEATS");

            // validate the users input using a while loop that checks for blank spaces, non numbers, and restricts numbers to 1 through 4 using a pre defined array.
            while (!int.TryParse(Console.ReadLine(), out itemSelection) || !validSelection.Contains(itemSelection)) {
                // tell the user what went wrong
                Console.WriteLine("Please enter a vaild menu selection of 1, 2, 3, or 4 and press RETURN.");
            }

            Console.WriteLine("\r\n");

            // now that we have a valid input we can calculate the cart
            // I am using the foreach loop and creating a string called elements to compare to the users chosen item from the menu
            // the array I built called chosenItem will have an index of one number off the itemSelection variable I created to store the users
            // input choice. So I simply use the itemSelection -1 as my index compare the correct information from both arrays
            // if the element from items array and the chosenItem are the same then it simply increases the itemcount by 1
            foreach (string element in items) {
                if (element == chosenItem[itemSelection - 1]) {
                    itemCount++;
                    
                }
            }

            // tell the user how many items and what is in the cart.
            Console.WriteLine("In the shopping cart there are {0} {1}s.", itemCount, chosenItem[itemSelection - 1]);
            
            /*
             * Each menu item did work correctly for 1,2,3, and 4
             * When typing the number 6 the result is "Please enter a valid menu selection of 1,2,3, or 4 and press RETURN."
             * 
             * If I add more items to the cart array, the code works just fine
             * 
             * user choice - 1 Snacks
             * Result - "In the shopping cart there are 3 Snacks."
             * 
             * User choice - 2 Drinks
             * Results - "In the shopping cart there are 4 drinks"
             * 
             */
        }
    }
}

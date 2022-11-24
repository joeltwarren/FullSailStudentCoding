using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Joel Warren
             * 4-22-2018
             * Lists Assignment
             * 
            */
            
            // welcome the user to the Grocery List
            Console.WriteLine("Hi here is your grocery shopping list for today!\r\n");
            
            
            // create two lists one with items and one with the items prices
            List<string> items = new List<string>() {"Grapes","Apples","Oranges","Pineapples","Peaches","Plums","Strayberrys","Cherries","Bannas","Grapefruits" };
            List<decimal> prices = new List<decimal>() {1.35M, 2.25M, 3.75M, 4.33M, 5.25M, 6.50M, 7.75M, 8.12M, 9.16M, 10.11M };

            // create a for Loop to round all the decimals in the Prices list to 2 digits awayfrom zero at the midpoint
            for (int i = 0; i < prices.Count; i++) {

                // iterates through the prices list one by one round each value
                prices[i] = decimal.Round(prices[i], 2, MidpointRounding.AwayFromZero);

            }

            // create the function to combine the two lists into a single string
            CombineTheLists(items, prices);

            // notify the user of whats about to happen and force a readline to pause the program allowing the user to read before the changes occur
            Console.WriteLine("We are going to be making some changes to the list and will give you an updated shopping list shortly.");
            Console.WriteLine("Please press RETURN to continue");
            Console.ReadLine();

            // create a int variable to make sure that I dont fat finger and remove different indicies from the list
            int item1ToRemove = 2;
            int item2ToRemove = 4;

            // time to remove the grocery shopping list items now
            items.RemoveAt(item1ToRemove);
            prices.RemoveAt(item1ToRemove);

            // removing the second item
            items.RemoveAt(item2ToRemove);
            prices.RemoveAt(item2ToRemove);

            // adding a new item to the front of both lists using insert so that I can make it at the FRONT of the list
            items.Insert(0, "BlackBerries");
            prices.Insert(0, .99M);

            // calling the CombineTheLists function
            CombineTheLists(items, prices);
            

        }

        public static void CombineTheLists(List<string> list1, List<decimal> list2) {
            // combine both list
            // create a string variable to hold the new combined list
            string combinedList = "";
            // variable to keepup with the list size
            int listSize = list1.Count;
            // for loop to combine the list values
            for (int i = 0; i < listSize; i++) {
                // iterates through both lists and adds the combined list indicies values to the text string conbinedList
                combinedList += "The " + list1[i] + " costs $" + list2[i] + "\r\n";
            }
            // using the function to output to the consoles since there is no return value calling the function will call the writeline to output the string to the user
            Console.WriteLine(combinedList);
        }
    }
}

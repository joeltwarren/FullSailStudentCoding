using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Joel Warren
             C201804 01
             3/30/2018
             Arrays Assignment
             */

            //Create your own project and call it Lastname_Firstname_Arrays
            //Copy this code inside of this Main section into your Main Section
            //Work through each of the sections

            /* 
              -Use the 2 arrays below
              -Do Not Re-Declare or Re-Define the elements inside of it.
              -Find the total sum of each individual array  
              -Store each sum in a variable and output that variable to console
              
              -Find the average value of each individual array
              -Store each average in a variable and output that variable to console
            */


            //This is the Declare and Definition of the 2 Starting Number Arrays
            int[] firstArray = new int[4] { 7, 24, 30, 12 };
            double[] secondArray = new double[4] { 9, 20.5, 35.9, 237.24 };

            // I simply created my firstArrayTotals as a decimal variable to allow my average to properly divide 73 by 4 and preserve the decimals
            // Declared and Defined while doing the math all at once
            decimal firstArrayTotals = firstArray[0] + firstArray[1] + firstArray[2] + firstArray[3];
            
            // writing results plus descriptive text using cancatanation and a new line 
            Console.WriteLine("The First Int Array Total = "+firstArrayTotals + "\r\n");

            // I kept the type double for the second array as it will allow the decimals to be preserved anyway
            // declared and defined while doing the math for my secondArrayTotals variable
            double secondArrayTotals = secondArray[0] + secondArray[1] + secondArray[2] + secondArray[3];
            
            // writing results plus descriptive text using cancatanation and a new line
            Console.WriteLine("The Second Double Array Total = " +secondArrayTotals + "\r\n");
            
            // finding the average again using decimal as the type to presever the decimals
            decimal firstArrayAverage = firstArrayTotals / 4;
            
            // writing results plus descriptive text using cancatanation and a new line
            Console.WriteLine("The Average of the First Array is " + firstArrayAverage + "\r\n");
            
            // finding the average of the double
            double secondArrayAverage = secondArrayTotals / 4;
            
            // writing results plus descriptive text using cancatanation and a new line
            Console.WriteLine("The Average of the Second Array is " + secondArrayAverage+ "\r\n");




            /*
               Create a 3rd number array.  
               The values of this array will come from the 2 given arrays.
                -You will take the first item in each of the 2 number arrays, add them together and then store this sum inside of the new array.
                -For example Add the index#0 of array 1 to index#0 of array2 and store this inside of your new array at the index#0 spot.
                    -This would make the first element of this array = 16
                -Repeat this for each index #.
                -Do not add them by hand, the computer must add them.
                -Do not use the numbers themselves, use the array elements.
                -After you have the completed new array, output this to the Console.
             */

            //Your code for the 3d Array goes here

            // I declared the array without defining it
            decimal[] thirdArray= new decimal[4];

            // Defining the array by adding all elements from array one to array two and storing them in array 3
            // Note I also had to do an explicit conversion of both types to decimals before being able to add them and store them
            // I am doing this for each index as well
            thirdArray[0] = (decimal)firstArray[0] + (decimal)secondArray[0];
            thirdArray[1] = (decimal)firstArray[1] + (decimal)secondArray[1];
            thirdArray[2] = (decimal)firstArray[2] + (decimal)secondArray[2];
            thirdArray[3] = (decimal)firstArray[3] + (decimal)secondArray[3];

            // writing the addition results out to the console and adding descriptive text
            // writing the new line at the end
            // would have prefered a for each loop here i could get the string.Join to list them all just not with the descriptive text included lol
            Console.WriteLine("The Third Array has the Following Values ");
            Console.WriteLine("Index position 0 = " + thirdArray[0]);
            Console.WriteLine("Index position 1 = " + thirdArray[1]);
            Console.WriteLine("Index position 2 = " + thirdArray[2]);
            Console.WriteLine("Index position 3 = " + thirdArray[3]);
            Console.WriteLine("\r\n");
            /*
               Given the array of strings below named MixedUp.  
               You must create a string variable that puts the items in the correct order to make a complete sentence 
               that is a famous phrase by Bill Gates.
                -Use each element in the array, do not re-write the strings themselves.
                - Do Not Re-Declare or Re-Define the elements inside of it.
                -Concatenate them in the correct order to form a sentence.
                -Store this new sentence string inside of a string variable you create.
                -Output this new string variable to the console.
             */

            //Declare and Define The String Array
            string[] MixedUp = new string[] { " is like measuring ", "Measuring programming progress", "aircraft building progress ", " by lines of code", "by weight." };

            // declaring the string variable
            string billGatesSaid ;

            // Defining the String with concatenation
            // The Spaces were a nice hint :)
            billGatesSaid = MixedUp[1] + MixedUp[3] + MixedUp[0] + MixedUp[2] + MixedUp[4];

            // Writing the String to the Console
            Console.WriteLine("Bill Gates said that - "+billGatesSaid);
        }
    }
}

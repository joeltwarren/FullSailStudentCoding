using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_MadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Joel Warren
             * C201804 01
             * MadLibs Assignment
            */
            // Welcoming everyone to the Mad Libs
            Console.WriteLine("Welcome to the Mad Libs" + "\r\n");

            // Asking the users name first
            Console.WriteLine("What is your name? Please press return after you enter it" + "\r\n");

            // capturing the users name and storing it in a new variable
            string usersName = Console.ReadLine();

            // Obataining the answers to the required user prompts and storing them all in local string variables using concatenation
            Console.WriteLine(usersName + " I need you to give me an Occupation then hit return");
            string occupation = Console.ReadLine();

            Console.WriteLine(usersName + " I need you to give me a Color then hit return");
            string color = Console.ReadLine();

            Console.WriteLine(usersName + " I need you to give me a Past Tense Action Verb then hit return");
            string verb = Console.ReadLine();
            
            Console.WriteLine(usersName + " I need you to give me a Singlular Noun then hit return");
            string noun = Console.ReadLine();
            
            Console.WriteLine(usersName + " I need you to give me an Age then hit return");
            string age = Console.ReadLine();

            Console.WriteLine(usersName + " I need you to give me a Cost then hit return");
            string cost = Console.ReadLine();            

            Console.WriteLine(usersName + " I need you to give me a Random Number then hit return");
            string randomNumber = Console.ReadLine();
            
            // Converting the user promted numbers into a data type I can work with instead of strings and storing them in an array
            double convertedAge = double.Parse(age);
            double convertedCost = double.Parse(cost);
            double convertedRandomNumber = double.Parse(randomNumber);

            // declaring the array and defining it with converted numbers
            double[] convertedNumbersArray = {convertedAge,convertedCost,convertedRandomNumber};

            // starting the output of the MadLib to the Console using variables and array indicies for indicies
            Console.WriteLine("A "+convertedNumbersArray[0] +" year old " +occupation + " registered for a "+ convertedNumbersArray[2] + "K marathon.");
            Console.WriteLine("The Jersey was " + color + " and cost $" +convertedNumbersArray[1] + ".");
            Console.WriteLine("On the last leg of the marathon everyone " +verb + " on a " +noun + ".");
            
            


        }
    }
}

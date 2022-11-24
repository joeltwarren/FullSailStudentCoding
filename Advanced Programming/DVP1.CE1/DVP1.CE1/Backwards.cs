using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be used to take a sentence of at least 6 words and reverse the whole sentence letter by letter.

namespace DVP1.CE1
{
    class Backwards
    {
        public static void ShowBackwards() {

            // clear the console and add the ASCII
            Console.Clear();

            Console.WriteLine(@"
  ___          _                       _    
 | _ ) __ _ __| |____ __ ____ _ _ _ __| |___
 | _ \/ _` / _| / /\ V  V / _` | '_/ _` (_-<
 |___/\__,_\__|_\_\ \_/\_/\__,_|_| \__,_/__/
======================================================================
======================================================================

Welcome to Backwards:

To begin, please enter a sentence containing at least 6 words and press return");

            // variables for starting the process of data collection
            string usersSentence = Console.ReadLine();
            string[] validationArray = usersSentence.Split(' ');

            // validation using the created array I am checking to make sure the array has at least 6 elements representing 6 words.
            while (validationArray.Length < 6) {

                Console.WriteLine("Please enter at least 6 words in your sentence and press return");
                usersSentence = Console.ReadLine();
                validationArray = usersSentence.Split(' ');
            }
            // declare a variable to hold the validated sentence
            string validatedSentence = "";

            // loop through the array to recreate the sentence
            foreach (var word in validationArray) {
                
                validatedSentence = validatedSentence + word + " ";
                
            }

            // display the sentence back to the user.
            Console.WriteLine("\r\n");
            Console.WriteLine($"The sentence you entered was: \r\n{validatedSentence}");

            // declaring a string to hold the reveresed sentence
            string reversed = "";
            // creating a character array to use to reverse the string
            char[] reversedSentence = validatedSentence.Reverse().ToArray();
            foreach (char letter in reversedSentence) {
                reversed += letter;

            }
            // triming leading and ending whitespaces since the array above inserts a blank space at the last word entered 
            reversed = reversed.Trim();


            // output the results
            Console.WriteLine("\r\n");
            Console.WriteLine($"Backwards this sentence would read: \r\n{reversed}");

            Console.WriteLine("\r\n");
            Console.WriteLine(@"======================================================================
Press any key to return to the Main Menu:");
        }
    }
}

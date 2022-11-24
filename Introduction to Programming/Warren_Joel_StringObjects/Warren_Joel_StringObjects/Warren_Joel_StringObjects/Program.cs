using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_StringObjects
{
    class Program
    {
        static void Main(string[] args)
        {

            // Problem #1 Phone Number Checker

            // weclome the user
            Console.WriteLine("Welcome to the phone number checker.");
            // Prompt the user for a telephone number with a required mask
            Console.WriteLine("Please enter a telephone number using the following format (###) ###-####");

            // catch the users input
            string usersPhoneNumberString = Console.ReadLine();

            // validate the field is not left blank
            while (string.IsNullOrEmpty(usersPhoneNumberString)) {
                // PLease do not leave this blank
                Console.WriteLine("It appears you left this blank\r\nPlease enter a telephone number using the following format (###) ###-####");

                // re-catch the users input
                usersPhoneNumberString = Console.ReadLine();
            }

            // create a function to check for valid and call its results
            string isValid = ValidationCheck(usersPhoneNumberString);

            // conditional to output users responce based on whether or not the phone number was valid
            if (isValid == "valid")
            {

                Console.WriteLine("The phone number you entered of {0} is a {1} telephone number.", usersPhoneNumberString, isValid);


            }
            else {

                Console.WriteLine("The phone number you entered of {0} is an {1} telephone number.", usersPhoneNumberString, isValid);


            }

            /*Test Values of the Phone Number Checker
             * 
             * Input - (123) 456-7890
             * Output - "The phone number you entered of (123) 456-7890 is a valid telephone number."
             * 
             * Input - (123	456-7890
             * Output - "The phone number you entered of (123 456-7890 is an invalid telephone number."
             * 
             * Input - 123-456-7890
             * Output - "The phone number you entered of 123-456-7890 is an invalid telephone number."
             * 
             * Input - 1234567890
             * Output - "The phone number you entered of 1234567890 is an invalid telephone number."
             * 
             * Input - (joe) lwa-rren
             * Output - "The phone number you entered of (joe) lwa-rren is an invalid telephone number."
             * 
            */

            // new line character
            Console.WriteLine("\r\n");

            // Problem # 2 Decipher
            // welcome the user to the new Decipher Program
            Console.WriteLine("Welcome to the Decipher Program");

            // request the users input and store it in a variable
            Console.WriteLine("Please enter the encrypted text string and press RETURN.");
            Console.WriteLine("Repalce the following values with these encrypted characters");
            Console.WriteLine(" a = @ \r\n e = # \r\n i = ^ \r\n o = * \r\n u = +");

            // create a variable to catch the users input
            string usersInput = Console.ReadLine();

            // validate its not left blank
            while (string.IsNullOrWhiteSpace(usersInput)) {
                // this will run until the user enters something other than leaving it empty
                // tell the user whats wrong
                Console.WriteLine("Please do not leave this blank.\r\n");
                Console.WriteLine("Please enter the encrypted text string and press RETURN.");
                Console.WriteLine("Repalce the following values with these encrypted characters");
                Console.WriteLine(" a = @ \r\n e = # \r\n i = ^ \r\n o = * \r\n u = +");

                // re-catch the users input
                usersInput = Console.ReadLine();

                
            }

            // create the function and do the function call
            string usersDecryptedInput = DecipherInput(usersInput);
            Console.WriteLine("The encrypted text is {0} Deciphered the text is {1}", usersInput, usersDecryptedInput);

            /*
             * Input - Encrypted String 1 - Str^ng *bj#cts c@n b# f+n t* w*rk w^th!
             * Output - The encrypted text is Str^ng *bj#cts c@n b# f+n t* w*rk w^th! Deciphered the text is String objects can be fun to work with!
             * 
             * Input - Encrypted string 2 - D#b+gg^ng ^s th# pr*c#ss *f r#m*v^ng s*ftw@r# b+gs, th#n pr*gr@mm^ng m+st b# th# pr*c#ss *f p+tt^ng th#m ^n.
             * Output - The encrypted text is D#b+gg^ng ^s th# pr*c#ss *f r#m*v^ng s*ftw@r# b+gs, th#n pr*gr@mm^ng m+st b# th# pr*c#ss *f p+tt^ng th#m ^n. Deciphered the text is Debugging is the process of removing software bugs, then programming must be the process of putting them in.
             * 
             * Input - Encrypted string 3 - Th^s w@s n#at t* l#@rn!
             * Output - The encrypted text is Th^s w@s n#at t* l#@rn! Deciphered the text is This was neat to learn!
            */



        }
        // Method for Decipher
        public static string DecipherInput(string encryptedText) {

            // start by setting the string out to an array using .ToCharArray method
            // created a array of type char to catch the individual characters in the string and store them in the array
            char [] characters = encryptedText.ToCharArray();

            // creating a variable to store the lenght of the array in
            int arrayLenght = characters.Length;

            // for loop to check all the characters for encrypted symbols
            for (int i = 0; i < arrayLenght; i++ )
            {
                // long if / else if statement to determine what characters to swap if any
                if (characters[i] == '@')
                {
                    characters[i] = 'a';
                }
                else if (characters[i] == '#')
                {
                    characters[i] = 'e';
                }
                else if (characters[i] == '^')
                {
                    characters[i] = 'i';
                }
                else if (characters[i] == '*')
                {
                    characters[i] = 'o';
                }
                else if (characters[i] == '+')
                {
                    characters[i] = 'u';
                }
                else {
                    characters[i] = characters[i];
                }

            }
            string result = new string(characters);
            return result;
        }


        // method for Phone Number Checker
        public static string ValidationCheck(string usersInput) {
            // giving credit where credit is due
            // https://blog.maartenballiauw.be/post/2017/04/24/making-string-validation-faster-no-regular-expressions.html
            // I found something very simular to this code on the above website however I did modify and notate heavliy how I 
            // changed this code to make it work for what I was trying to do
            // I was already working on a similar method that was not this clean and this was exactly what I wanted it to do


            // create a variable to hold the string usersInput length
            int lenght = usersInput.Length;

            // create a bool variable to determine if the strings lenght is true or false to determine if the loop should be ran at all
            bool isCorrect = lenght == 14;

            
            // if the bool isCorrect is true then our usersInput has our required 14 characters

            // validate for the correct location of the required location characters - "(", ")", " ", "-"
            // as long as the required characters are in the correct location we will begin our if statement and for loop to validate the whole string
            // if it is false if will simply return the isCorrect = false
            // setting the isValid variable to "invalid" and passing it to the rest of the program
            isCorrect = (usersInput[0] == '(')
                     && (usersInput[4] == ')')
                     && (usersInput[5] == ' ')
                     && (usersInput[9] == '-');

            // using an if statement to verify that every character in the phone number is an accepted character
            if (isCorrect) {
                // the for loop uses the variable lenght created by counting the usersInput first if this fails the if loop never runs
                // as long as the i is less than the lenght the for loop keeps testing each character
                // I used || or's so that at anytime its true it goes ahead and runs the next for loop
                for (int i = 0; i < lenght; i++) {
                    // setting isCorrect to true or false testing every character in our allowed character list
                    // if any character is invalid it will cause the code to spit out isCorrect = false which breaks the for loop
                    // with the || once it reaches a true statement it simply skips the rest and reloops described as a short circuit
                     
                    isCorrect = (usersInput[i] == '(')
                        || (usersInput[i] == '1')
                        || (usersInput[i] == '2')
                        || (usersInput[i] == '3')
                        || (usersInput[i] == '4')
                        || (usersInput[i] == '5')
                        || (usersInput[i] == '6')
                        || (usersInput[i] == '7')
                        || (usersInput[i] == '8')
                        || (usersInput[i] == '9')
                        || (usersInput[i] == '0')
                        || (usersInput[i] == ')')
                        || (usersInput[i] == '-')
                        || (usersInput[i] == ' ');
                    

                    // breaks the loop by setting the isCorrect bool to false
                    if (!isCorrect) isCorrect = false;

                }
                

            }

            // use our bool value to determine if the input was valid or invalid
            // create a variable to store the valid/invalid response
            string isValid;

            // if statement to set the value of isValid based on the bool result from our validation testing
            if (isCorrect)
            {
                isValid = "valid";
            }
            else {
                isValid = "invalid";
            }

            return isValid;

        }
    }
}

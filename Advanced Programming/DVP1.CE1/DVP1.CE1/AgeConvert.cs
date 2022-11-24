using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be used to convert the users age to days, hours, minutes, and seconds instead of just years.

namespace DVP1.CE1
{
    class AgeConvert
    {
        public static void AgeConversion() {
            // clear the console and add the ASCII
            Console.Clear();
            Console.WriteLine(@"
    _             ___                     _   
   /_\  __ _ ___ / __|___ _ ___ _____ _ _| |_ 
  / _ \/ _` / -_) (__/ _ \ ' \ V / -_) '_|  _|
 /_/ \_\__, \___|\___\___/_||_\_/\___|_|  \__|
       |___/                                  
======================================================================
======================================================================

Welcome to AgeConvert:

To begin, please enter your name and press return");

            // caputure the users input, validate it and display it back out to the screen
            string usersName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace (usersName)) {
                Console.WriteLine("Please do not leave this blank enter your name and press return.");
                usersName = Console.ReadLine();
            }

            Console.WriteLine($"Thank you {usersName}. Next I will need your birthday (format: mm/dd/yy) or your age. \r\n");
            Console.WriteLine($"{usersName} Please choose and option below and press return");
            Console.WriteLine("[1] for entering your birthday - More Accurate Response");
            Console.WriteLine("[2] for entering your age - Less Accurate Response");
            string usersChoice = Console.ReadLine();

            // validate the users menu selection
            int.TryParse(usersChoice, out int usersConvertedChoice);
            while (usersConvertedChoice != 1 && usersConvertedChoice != 2) {
                Console.WriteLine("Please Enter a Vaild Menu Number of [1] for birthday or [2] for age and press return");
                usersChoice = Console.ReadLine();
                int.TryParse(usersChoice, out usersConvertedChoice);
            }

            // Action taken based on users entered choices
            if (usersConvertedChoice == 1)
            {
                // ask for birthday
                Console.WriteLine("Please enter your birthday MM/DD/YY HH:MM:SS and it cannot be earlier than 01/01/1908");
                Console.WriteLine("Example Date: \"12/22/82 06:30 AM\" or \"12/22/82\"");

                // capture input
                string usersBirthday = Console.ReadLine();

                // create a variable to store the result of validdate class call
                bool isValid = ValidDate.IsDateValid(usersBirthday);

                // action based on reslut of validdate call
                if (isValid == true)
                {
                    // if its valid make it known and include the time incase we need it to calculate
                    DateTime.TryParse(usersBirthday, out DateTime validatedBirthday);

                    // determine users age
                    int age = DateTime.Now.Year - validatedBirthday.Year;

                    // determine if the users birthday has passed in this year or not if not subtract one from age
                    if (DateTime.Now.Month < validatedBirthday.Month || (DateTime.Now.Month == validatedBirthday.Month && DateTime.Now.Day < validatedBirthday.Day )) {
                        age--;
                    }
                    // using timespan to determine number of days, hours, mins, and seconds old.
                    TimeSpan usersAge = DateTime.Now - validatedBirthday;
                    double numOfDays = usersAge.TotalDays;
                    double numOfHrs = usersAge.TotalHours;
                    double numOfMins = usersAge.TotalMinutes;
                    double numOfSecs = usersAge.TotalSeconds;

                    // rounding to keep display of totals simple 
                    numOfDays = Math.Round(numOfDays, 0);
                    numOfHrs = Math.Round(numOfHrs, 0);
                    numOfMins = Math.Round(numOfMins, 0);
                    numOfSecs = Math.Round(numOfSecs, 0);
                    
                    // outputting the information to the user
                    Console.WriteLine($"{usersName} you are {age} years old! Next time try answering with");
                    Console.WriteLine($"{numOfDays.ToString("#,##0")} days old -or-");
                    Console.WriteLine($"{numOfHrs.ToString("#,##0")} hours old -or-");
                    Console.WriteLine($"{numOfMins.ToString("#,##0")} minutes old -or-");
                    Console.WriteLine($"{numOfSecs.ToString("#,##0")} seconds old");
                }
                else {
                    Console.WriteLine("there was an error please try again");
                    AgeConvert.AgeConversion();
                }


            }
            // second action based on users choice
            else if (usersConvertedChoice == 2)
            {
                // ask for users age in numeric form
                Console.WriteLine($"{usersName} Please enter your age and press return");

                // capture input and store it
                string usersEnteredAge = Console.ReadLine();
                int usersConvertedAge;

                // validate users entered age to be an interger
                while (!int.TryParse(usersEnteredAge, out usersConvertedAge))
                {
                    Console.WriteLine($"{usersName} Please enter a valid age and press return");
                    usersEnteredAge = Console.ReadLine();
                }
                // doing the math based on a static number of years entered
                decimal daysOld = usersConvertedAge * 365.25m;
                decimal hoursOld = usersConvertedAge * 8760;
                decimal minsOld = usersConvertedAge * 525600;
                decimal secsOld = usersConvertedAge * 31557600;

                // outputting the answers to the user
                Console.WriteLine($"You are {usersConvertedAge} years old! Next time try answering with");
                Console.WriteLine($"{daysOld.ToString("#,##0")} days old -or-");
                Console.WriteLine($"{hoursOld.ToString("#,##0")} hours old -or-");
                Console.WriteLine($"{minsOld.ToString("#,##0")} minutes old -or-");
                Console.WriteLine($"{secsOld.ToString("#,##0")} seconds old");


            }
            else {
                Console.WriteLine("The Program errored out! Try again");
                Console.Clear();
                AgeConvert.AgeConversion();
            }
            
            Console.WriteLine(@"
======================================================================
Press any key to return to the main menu:");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be used to convert either a Fahrenheit to Celsisu temperature or vise versa.

namespace DVP1.CE1
{
    class TempConvert
    {
        public static void ConvertTemp() {

            // cleared the console and added ASCII
            Console.Clear();
            Console.WriteLine(@"
  _____                ___                     _   
 |_   _|__ _ __  _ __ / __|___ _ ___ _____ _ _| |_ 
   | |/ -_) '  \| '_ \ (__/ _ \ ' \ V / -_) '_|  _|
   |_|\___|_|_|_| .__/\___\___/_||_\_/\___|_|  \__|
                |_|                                
======================================================================
======================================================================

Welcome to TempConvert ");

            Console.WriteLine("Please tell me what type of tempature you would like to convert");
            Console.WriteLine(@"
[1] Fahrenheit
[2] Celsius
[3] Kelvin
");
            // capture users input
            string usersChoice = Console.ReadLine();

            // create requried variables and array
            int[] validChoice = new int[] {1, 2, 3 };
            int convertedUsersChoice;
            string usersFirstScale;
            
            // validaion of uses menu choice selection
            while (!int.TryParse(usersChoice, out convertedUsersChoice) || (!validChoice.Contains(convertedUsersChoice))) {
                Console.WriteLine("Please enter a valid menu item 1, 2, or 3");
                usersChoice = Console.ReadLine();
            }

            // ask user for the tempature they want to convert
            Console.WriteLine("Please enter the numeric tempature you would like to convert");
            
            // catch uses input
            string usersTempature = Console.ReadLine();

            // validate temp to confirm its an interger
            int usersConvertedTemp;
            while (!int.TryParse(usersTempature, out usersConvertedTemp)) {
                Console.WriteLine("Please enter a number");
                usersTempature = Console.ReadLine();
            }

            // set users select choice of scale and set the first scale to change from
            if (convertedUsersChoice == 1)
            {
                usersFirstScale = "Fahrenheit";
            }
            else if (convertedUsersChoice == 2)
            {
                usersFirstScale = "Celsius";

            }
            else
            {
                usersFirstScale = "Kelvin";

            }

            // ask user what to convert the temp to
            Console.WriteLine($"Please tell me which scale you would like to convert your {usersConvertedTemp} degrees {usersFirstScale} to?");
            Console.WriteLine(@"
[1] Fahrenheit
[2] Celsius
[3] Kelvin
");
            // catch users response
            string usersConvertingTo = Console.ReadLine();

            // validation variable
            int usersConvertingToNum;
           
            // validation of second menu selection before conversion can happen
            while (!int.TryParse(usersConvertingTo, out usersConvertingToNum) || (!validChoice.Contains(usersConvertingToNum)))
            {
                Console.WriteLine("Please enter a valid menu item 1, 2, or 3");
                usersConvertingTo = Console.ReadLine();
            }

            // set scale to convert to
            string usersSecondScale;
            if (usersConvertingToNum == 1)
            {
                usersSecondScale = "Fahrenheit";
            }
            else if (usersConvertingToNum == 2)
            {
                usersSecondScale = "Celsius";

            }
            else
            {
                usersSecondScale = "Kelvin";

            }

            // set variable to store converted temp
            double usersNewTemp;
            
            // action based on users choices of from and to scales.
            if (convertedUsersChoice == 1 && usersConvertingToNum == 1)
            {
                // degrees Fahrenheit to Fahrenheit no conversion necessary
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersConvertedTemp} degrees {usersSecondScale}");
            }
            else if (convertedUsersChoice == 1 && usersConvertingToNum == 2)
            {
                // degrees Fahrenheit to Celsius
                usersNewTemp =  5.0 / 9.0 * (usersConvertedTemp - 32);
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 1 && usersConvertingToNum == 3)
            {
                // degrees Fahrenheit to Kelvin
                usersNewTemp = (usersConvertedTemp + 459.67) * 5.0 / 9.0;
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 2 && usersConvertingToNum == 1)
            {
                // degrees Celsius to Fahrenheit
                usersNewTemp = (usersConvertedTemp * 9.0 / 5.0) + 32;
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 2 && usersConvertingToNum == 2)
            {
                // degrees Celsius to Celsius no conversion needed
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersConvertedTemp} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 2 && usersConvertingToNum == 3)
            {
                // degrees Celsius to Kelvin
                usersNewTemp = usersConvertedTemp + 273.15;
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 3 && usersConvertingToNum == 1)
            {
                // degrees Kelvin to Fahrenheit
                usersNewTemp = (usersConvertedTemp * 9.0 / 5.0) - 459.67;
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 3 && usersConvertingToNum == 2)
            {
                // degrees Kelvin to Celsius
                usersNewTemp = usersConvertedTemp - 273.15 ;
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersNewTemp.ToString("#,##0.##")} degrees {usersSecondScale}");

            }
            else if (convertedUsersChoice == 3 && usersConvertingToNum == 3)
            {
                // degrees Kelvin to Kelvin no conversion needed
                Console.WriteLine($"You chose to convert {usersConvertedTemp} in degrees {usersFirstScale} to {usersSecondScale}");
                Console.WriteLine($"Your converted tempature is {usersConvertedTemp} degrees {usersSecondScale}");

            }
            else {
                Console.WriteLine("Something went wrong try again");
                Console.WriteLine("Press any Key to Contine!");
                Console.ReadKey();
                Console.Clear();
                ConvertTemp();
            }

            
            Console.WriteLine(@"
======================================================================
Press any key to return to the main menu: ");


        }
    }
}

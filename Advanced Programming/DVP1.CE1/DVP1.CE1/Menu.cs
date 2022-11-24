using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be a welcome point or menu to allow the user to run any challenges that have been completed.

namespace DVP1.CE1
{
    class Menu
    {
        static public void MainMenu ()

        
        {
            // Variables for users choices
            string usersChoice;
            int usersChoiceConverted;

            // arrays for input validation
            int[] acceptableInput = new int[6] { 0,1,2,3,4,5};

            
            // Identify the Program and list the challange menu for the user to choose from.
            // Included the Example ASCII Text Art from the Sample using a literal @.
         
            // set a variable to the title I wanted to use the ASCII for 
            Console.Clear();
            string title = @"
  ___          _        _       _     ___         _    __     _ _     
 | _ \_ _ ___ (_)___ __| |_   _| |_  | _ \___ _ _| |_ / _|___| (_)___ 
 |  _/ '_/ _ \| / -_) _|  _| |_   _| |  _/ _ \ '_|  _|  _/ _ \ | / _ \
 |_| |_| \___// \___\__|\__|   |_|   |_| \___/_|  \__|_| \___/_|_\___/
             |__/  
======================================================================
======================================================================";

            Console.WriteLine(title);
            // Give the user the menu to Choose from for challanges
            // recreated the Coding challenge Menu using literals and a variable
            string programMainMenu = @"
    Coding Challenge Menu:

    Please enter the number for the challenge you want to run...

    [1] Swap Name
    [2] Backwards
    [3] Age Convert
    [4] Temp Convert
    [5] Big Blue Fish

    [0] Exit the Program

======================================================================

Make your selection and then press return";

            
            // code to call the main menu to the console.
            Console.WriteLine(programMainMenu);
            usersChoice = Console.ReadLine();

            // Validation 
            while (!int.TryParse(usersChoice, out usersChoiceConverted) || !acceptableInput.Contains(usersChoiceConverted)) {
                // notify user of whats going on
                Console.WriteLine("You must choose a number listed");

                // catch the users input again and store it
                usersChoice = Console.ReadLine();

            }

            // this is how the captured input is used to pick a class to run
            // then after each class the console is cleared and the main menu is run again.
            if (usersChoiceConverted == 1) {
                
                SwapName.NameSwap();
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            } else if (usersChoiceConverted == 2) {

                Backwards.ShowBackwards();
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            } else if (usersChoiceConverted == 3) {

                AgeConvert.AgeConversion();
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            } else if (usersChoiceConverted == 4) {

                TempConvert.ConvertTemp();
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            } else if (usersChoiceConverted == 5) {

                BigBlueFish.FindTheFish();
                Console.ReadKey();
                Console.Clear();
                MainMenu();

            }  else {

                Environment.Exit(0);
                Console.WriteLine("You Chose to Exit the Program");


            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This Class Populates the menu, calls validation on the users input, and returns the users menu selection.
/// </summary>
namespace JoelWarren_CE_01
{
    class Menu
    {
        public static int DisplayMenu()
        {
            string menu = @"Please Choose a Menu Option!

[1.] Create Customer
[2.] Create Account
[3.] Set Account Balance
[4.] Display Account Balance
[0.] Exit The Program
Selection: ";

            // display the menu
            Console.Write(menu);
            // Capturing the uses Input
            string menuSelection = Console.ReadLine();
            // setting an array of valid selections from the menu since its a hardcoded menu
            int[] validMenuOptions = new int[] { 0, 1, 2, 3, 4 };
            // call to validation method
            int CurrentSelection = Validation.ValidArrayMenuSelection(menuSelection, validMenuOptions);

            return CurrentSelection;
        }
    }
}

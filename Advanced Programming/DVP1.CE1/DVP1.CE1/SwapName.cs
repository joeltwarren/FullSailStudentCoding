using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be a string exercise where we reverse the users input for first and last name.

namespace DVP1.CE1
{
    class SwapName
    {
        static public string ReverseName (string _firstName, string _lastname){
            // this is called at the end of Name swap thats where the variables to complete this come from.
            string reverseName = _lastname +", "+ _firstName;
            return reverseName;

}
        static public void NameSwap() {

            // declared variables

            string firstName;
            string lastName;


            // beginning of swap name
            Console.Clear();
            
            string title = @"
  ___                  _  _                
 / __|_ __ ____ _ _ __| \| |__ _ _ __  ___ 
 \__ \ V  V / _` | '_ \ .` / _` | '  \/ -_)
 |___/\_/\_/\__,_| .__/_|\_\__,_|_|_|_\___|
                 |_|
======================================================================
======================================================================

Welcome to SwapName:

To begin, Please enter your First Name then press return";


            Console.WriteLine(title);
            firstName = Console.ReadLine();

            // validation
            while (string.IsNullOrWhiteSpace(firstName)) {
                Console.WriteLine("Please do not leave your name blank!");
                firstName = Console.ReadLine();

            }
          
            Console.WriteLine($"Thank you {firstName}, I will now need your Last Name then press return");
            lastName = Console.ReadLine();

            // validation
          
            while (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Please do not leave your name blank!");
                lastName = Console.ReadLine();

            }

            // calling on ReverseName and feeding it the necessary parameters to complete the process.
            string newName = ReverseName(firstName, lastName);
            Console.WriteLine($"Excellent! Your name ({firstName} {lastName}) reversed would be {newName}.");
            Console.WriteLine("\r\n");
            Console.WriteLine(@"======================================================================
Press any key to return to the Main Menu:");

        }
    }
}

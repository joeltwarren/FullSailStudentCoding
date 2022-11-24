using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Main:
/// In main before anything else you will need a Customer variable to use for the currentCustomer.
/// Program runs until the user chooses to exit.
/// 
/// Menu:
/// The menu must have the following options:
/// Create customer - this option needs to prompt the user for a customer name, use that input to instantiate a new Customer object, and assign that object to the currentCustomer variable.
/// Create account - this option should only run if currentCustomer isn’t null, it needs to prompt the user for values to create a CheckingAccount with, use those values to instantiate a new CheckingAccount object and assign it to the currentCustomer.
/// Set account balance - this option should only run if currentCustomer isn’t null and currentCustomer’s account isn’t null, it needs to prompt the user for a new account balance and then apply it to currentCustomer’s account.
/// Display account balance - this option needs to display the current customer’s account balance.
/// Exit - stop the program.
/// 
/// Input Validation
/// User’s input must be validated.
/// The user must not be able to crash your program by entering invalid values.
/// 
/// Additional Challenge
/// (For anyone that wants to take their programming skills to the next level)
/// Change the currentCustomer variable to an array of customers and modify the menu options to allow the user to select which customer is being created etc.
/// You will have to either create a hardcoded array of customers or prompt the user for the number of customers the array should hold and enforce that limit.
/// </summary>

namespace JoelWarren_CE_01

{
    class Program
    {
        static void Main()
        {
            
            bool programIsRunning = true;
            Customer currentCustomer = null;
            
            while (programIsRunning)
            {
                // always run a console.clear because I do not run my code from a default repo
                Console.Clear();

                // display the main menu

                Console.WriteLine(@"

 +-+-+-+-+-+                                    
 |C|E|_|0|1|                                    
 +-+-+-+-+-+-+-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+-+-+
 |B|a|n|k| |T|e|l|l|e|r| |A|p|p|l|i|c|a|t|i|o|n|
 +-+-+-+-+ +-+-+-+-+-+-+ +-+-+-+-+-+-+-+-+-+-+-+
 |J|o|e|l| |W|a|r|r|e|n|                        
 +-+-+-+-+ +-+-+-+-+-+-+                        

================================================
================================================");

                // calling the menu & storing the users Choice
                int currentMenuSelection = Menu.DisplayMenu();

                switch (currentMenuSelection)
                {

                    case 1:
                        {

                            currentCustomer = CreateCustomer();
                        }
                        break;
                    case 2:
                        {
                            currentCustomer = CreateAccount(currentCustomer);

                        }
                        break;
                    case 3:
                        {
                            currentCustomer = SetAccountBalance(currentCustomer);

                        }
                        break;
                    case 4:
                        {

                            currentCustomer = DisplayAccount(currentCustomer);
                        }
                        break;
                    case 0:
                        {
                            programIsRunning = false;

                        }
                        break;
                }

            }
                    Utilities.Pause("Thank you for using the Teller Application!" + "\nPress any key to exit");
        }

        static Customer CreateCustomer()
        {
            Console.WriteLine("Please enter the customers name: ");
            string name = Validation.CheckforBlank(Console.ReadLine());
            Customer newCustomer = new Customer(name);
            
            return newCustomer;
        }

        static Customer CreateAccount(Customer currentCustomer)
        {
            if (currentCustomer != null)
            {
                int accountNumber = Validation.GetInt($"{currentCustomer.GetCustomersName()}'s new account number: ");
                decimal accountBalance = Validation.GetDecimal($"Please enter a new balance for Checking Account {accountNumber}: ");
                CheckingAccount currentAccount = new CheckingAccount(accountNumber,accountBalance);
                currentCustomer.SetCheckingAccount(currentAccount);
                
            } else
            {
                Utilities.Pause("Please Create a Customer First!\n" + "Press any Key to Continue:");
            }
            return currentCustomer;
        }
        static Customer SetAccountBalance(Customer currentCustomer)
        {
            // notify the user that you have to create a customer before setting a balance, clear the console, restart the menu and selection process
            if (currentCustomer == null)
            {
                Utilities.Pause("You must create a customer before setting an account balance\n" + "Press any Key to Continue:");
                
            }

            // notify the user that you have to create an account before setting a balance, clear the console, restart the menu and selecion process
            else if (currentCustomer != null && currentCustomer.GetCheckingAccount() == null)
            {
                Utilities.Pause("You must create an account before setting the balance\n" + "Press any Key to Continue:");
                
            }
            // set the account balance because the user has been created and the account has been created already
            else if (currentCustomer != null && currentCustomer.GetCheckingAccount() != null)
            {
                // inform the user of what the current balance is
                Console.WriteLine($"\nThe Balance of {currentCustomer.GetCustomersName().ToString()}'s Account {currentCustomer.GetAccountNumber().ToString()}  is {currentCustomer.GetAccountBalance().ToString("C")}");
                // prompt the user for a new balance and validate the input
                decimal newAccountBalance = Validation.GetDecimal("Please enter a new balance: ");
                // set the current checking account object balance based on users input
                currentCustomer.SetAccountBalance(newAccountBalance);
                // inform the user that the account balance has been updated
                Utilities.Pause($"Account {currentCustomer.GetAccountNumber().ToString()} now has a balance of {currentCustomer.GetAccountBalance().ToString("C")}" + "\nPress any Key to Continue:");
               
                
            }
            return currentCustomer;
            
        }

        static Customer DisplayAccount(Customer currentCustomer)
        {

            // if the account balance has been set then notify the user of the customers name, account number, and current balance
            if (currentCustomer != null &&currentCustomer.GetCheckingAccount() != null)
            {
                Console.WriteLine($"\nCustomer: {currentCustomer.GetCustomersName().ToString()}");
                Utilities.Pause($"Account: {currentCustomer.GetAccountNumber().ToString()} has a balance of {currentCustomer.GetAccountBalance().ToString("C")}" + "\nPress any Key to Continue:");
                
            }
            // if the account balance has not already been set then notifiy the user that they cannot continue until an account has been setup, clear the console, restart the menu and selection process
            else
            {
                Utilities.Pause("You cannot display the account balance until the account has been created and the balance set" + "\nPress any Key to Continue:");
            }

            return currentCustomer;
        }
    }
}

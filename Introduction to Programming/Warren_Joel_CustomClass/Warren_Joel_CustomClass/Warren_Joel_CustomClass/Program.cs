using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Joel Warren
             * 4-23-18
             * Custom Class Assignment
            */

            // welcome the user to the banking application
            Console.WriteLine("Welcome to our Custom Bankers App!");
            Console.WriteLine("\r\n");

            // prompting user for varialbes
            Console.WriteLine("Please enter your first name and press RETURN.");
            
            // catching the users response
            string usersFirstName = Console.ReadLine();
            Console.WriteLine("\r\n");

            // validate that the users did not leave the name blank
            while (string.IsNullOrWhiteSpace(usersFirstName)) {

                // code will run unitl the user enters something for a first name
                // tell the user what went wrong
                Console.WriteLine("Please do not leave blank and make sure you enter your first name and press RETURN.");
                
                // re-catch the users response
                usersFirstName = Console.ReadLine();
                Console.WriteLine("\r\n");
            }

            Console.WriteLine("Thank you {0} please enter your last name and press RETURN.", usersFirstName);
            // catching the users response
            string usersLastName = Console.ReadLine();
            Console.WriteLine("\r\n");

            // validate that the users did not leave the name blank
            while (string.IsNullOrWhiteSpace(usersLastName))
            {

                // code will run unitl the user enters something for a last name
                // tell the user what went wrong
                Console.WriteLine("Please do not leave blank and make sure you enter your last name and press RETURN.");

                // re-catch the users response
                usersLastName = Console.ReadLine();
                Console.WriteLine("\r\n");
            }

            // prompting the user for the starting bank account balance
            Console.WriteLine("Thank you {0} {1} please enter the starting balance of your Bank Account and press RETURN.", usersFirstName, usersLastName);
            // catching the users response
            string usersStartingBankAccountBalance = Console.ReadLine();
            Console.WriteLine("\r\n");

            //declare a decimal variable to hold the users starting bank balance
            decimal startingBankBalance;

            // validate that the user entered a string that can be converted into a decimal for money and its not Negative
            while (!decimal.TryParse(usersStartingBankAccountBalance, out startingBankBalance) | startingBankBalance < 0) {

                // code will run until they enter a vaild numeric value that is 0 or greater
                // tell the user what went wrong
                Console.WriteLine("Please enter a vaild numeric value that is $0.00 or greater and press RETURN.");

                // re-catch the users input
                usersStartingBankAccountBalance = Console.ReadLine();
                Console.WriteLine("\r\n");

            }

            // prompt the user for the starting checking account balance
            Console.WriteLine("Now {0} please enter the starting balance of your Checking Account and press RETURN.", usersFirstName);
            //catch the users response
            string usersStartingCheckingAccountBalance = Console.ReadLine();
            Console.WriteLine("\r\n");

            // declare a decimal variable to hold the users starting checking balance
            decimal startingCheckingBalance;

            // validate that the user entered a string that can be converted to a decimal for money and is not Negative
            while (!decimal.TryParse(usersStartingCheckingAccountBalance, out startingCheckingBalance) | startingCheckingBalance < 0) {

                // code will run until they enter a vaild numeric value that is 0 or greater
                // tell the user what went wrong
                Console.WriteLine("Please enter a vaild numeric value that is $0.00 or greater and press RETURN.");

                // re-catch the users input
                usersStartingCheckingAccountBalance = Console.ReadLine();
                Console.WriteLine("\r\n");

            }

            // since I prompted for a first and last name by the user I must create a single variable to pass to the constructor
            // creating the users full name string variable and defining it
            string usersFullName = usersFirstName + " "+ usersLastName;

            // time to instantiate the users Bank Account object
            // call the constructor and feed it the necessary 3 variables (string, decimal, decimal)
            BankAccount usersBankAccount = new BankAccount(usersFullName, startingBankBalance, startingCheckingBalance);

            // now that we can access all of our banckaccount properties we can continue the process
            
            // notify the user that the accounts have been created and they have X dollars in them using our newly created usersBankAccount Properties with formatted .ToString for currency
            Console.WriteLine("Ok {0} we have created your accounts.", usersFirstName);
            Console.WriteLine("The balance of your Bank Account is {0} and your Checking Account balance is {1}", usersBankAccount.GetBankBalance().ToString("C"), usersBankAccount.GetCheckingBalance().ToString("C"));
            Console.WriteLine("Your Total Balance of both accounts is {0}", usersBankAccount.GrandTotal().ToString("C"));
            Console.WriteLine("\r\n");


            // create an array of valid choices to use with my while conditional
            int[] validChoices = new int[] { 1, 2 };

            // Now that the user has the accounts created we can start the deposit / withdrawal process
            // we will start the loop that asks 3 times what the user wants to do
            for (int i = 0; i < 3; i++) {

                // this will loop 3 times and ask the user for input each time
                Console.WriteLine("{0} would you like make a deposit or a withdrawal", usersFirstName);
                Console.WriteLine("Please choose the from the following choices");
                Console.WriteLine("(1) for a Withdrawal \r\n(2) for a Deposit");

                // catch the users input of choice
                string usersResponse = Console.ReadLine();
                Console.WriteLine("\r\n");

                // variable to hold the users convereted response
                int usersConvertedResponse;

                // validate the users response
                while (!int.TryParse(usersResponse, out usersConvertedResponse) || !validChoices.Contains(usersConvertedResponse)) {

                    // this will run until the user has entered the correct response of 1 or 2
                    // notify the user that they have entered an incorrect value
                    Console.WriteLine("Please choose either option 1 for a withdrawal or option 2 for a deposit");

                    // re-catch the users input
                    usersResponse = Console.ReadLine();
                    Console.WriteLine("\r\n");

                }

                if (usersConvertedResponse == 1)
                {
                    // create a new users choice variable
                    string usersChoice;

                    // ask the users which account to perform the withdrawal from
                    Console.WriteLine("Thank you which account would you like to perform the withdrawal on?");
                    Console.WriteLine("Please choose the from the following choices");
                    Console.WriteLine("(1) for your Bank Account \r\n(2) for your Checking Account");

                    // catch the users input
                    usersChoice = Console.ReadLine();
                    Console.WriteLine("\r\n");

                    // new variable to hold the users second choice converted
                    int usersConvertedSecondChoice;

                    // validate the users response
                    while (!int.TryParse(usersChoice, out usersConvertedSecondChoice) || !validChoices.Contains(usersConvertedSecondChoice))
                    {

                        // this will run until the user has entered the correct response of 1 or 2
                        // notify the user that they have entered an incorrect value
                        Console.WriteLine("Please choose either option 1 for your Bank Account or option 2 for your Checking Account");

                        // re-catch the users input
                        usersChoice = Console.ReadLine();
                        Console.WriteLine("\r\n");

                    }

                    // we can now do the math for a withdrawal on the Account that was chose
                    if (usersConvertedSecondChoice == 1)
                    {

                        // variable to store the withdrawal amount
                        string withdrawalAmount;

                        // decimal variable to convert the withdrawal amount with
                        decimal convertedWithdrawal;
                        // ask the user for the withdrawal amount
                        Console.WriteLine("What is the amount that you would like to withdraw?");

                        // catch the users response
                        withdrawalAmount = Console.ReadLine();
                        Console.WriteLine("\r\n");

                        // validate the users response to make sure it is a number
                        while (!decimal.TryParse(withdrawalAmount, out convertedWithdrawal))
                        {
                            // tell the users what went wrong
                            Console.WriteLine("Please enter a vaild numeric withdrawal amount and press RETURN");

                            // re-catch the users withdrawal amount
                            withdrawalAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                        }

                        // do the actual math if the values dont make the account balance negative
                        // so we are validating the account can stand to have the money taken out now
                        while (usersBankAccount.GetBankBalance() < convertedWithdrawal)
                        {

                            // tell the user they do not have the funds available for this amount of withdrawal
                            Console.WriteLine("I am sorry you do not have that amount of funds available");
                            Console.WriteLine("Please choose a number less than {0}", usersBankAccount.GetBankBalance().ToString("C"));

                            // re-catch the users input
                            withdrawalAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                            // again validating that it is a number that was input and not something else this has to be done
                            // in order to make sure the users newly entered amount is try parsed or the while loop will run forever
                            if (!decimal.TryParse(withdrawalAmount, out convertedWithdrawal))
                            {
                                // tell the user to enter a vaild number again
                                Console.WriteLine("Please enter a vaild number less than {0}", usersBankAccount.GetBankBalance().ToString("C"));
                                // re- catch the users input
                                withdrawalAmount = Console.ReadLine();
                                Console.WriteLine("\r\n");
                                // keeping the tryparse running again for update reasons
                                decimal.TryParse(withdrawalAmount, out convertedWithdrawal);
                            }




                        }
                        // create a new decimal variable to perform the withdrawal with for the setter
                        decimal doTheWithdrawal;
                        doTheWithdrawal = usersBankAccount.GetBankBalance() - convertedWithdrawal;

                        // user the setter to change the bank account balance
                        usersBankAccount.SetBankAccountBalance(doTheWithdrawal);
                        Console.WriteLine("After your withdrawal of {0} your Bank Account balance is {1}.", convertedWithdrawal.ToString("C"), usersBankAccount.GetBankBalance().ToString("C"));
                        Console.WriteLine("Your Checking Account balance is {0}", usersBankAccount.GetCheckingBalance().ToString("C"));
                        Console.WriteLine("\r\n");



                    }
                    // doing the math on the account that was chose
                    else if (usersConvertedSecondChoice == 2)
                    {

                        // variable to store the withdrawal amount
                        string withdrawalAmount;

                        // decimal variable to convert the withdrawal amount with
                        decimal convertedWithdrawal;
                        // ask the user for the withdrawal amount
                        Console.WriteLine("What is the amount that you would like to withdraw?");

                        // catch the users response
                        withdrawalAmount = Console.ReadLine();
                        Console.WriteLine("\r\n");

                        // validate the users response to make sure it is a number
                        while (!decimal.TryParse(withdrawalAmount, out convertedWithdrawal))
                        {
                            // tell the users what went wrong
                            Console.WriteLine("Please enter a vaild numeric withdrawal amount and press RETURN");

                            // re-catch the users withdrawal amount
                            withdrawalAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                        }

                        // do the actual math if the values dont make the account balance negative
                        // so we are validating the account can stand to have the money taken out now
                        while (usersBankAccount.GetCheckingBalance() < convertedWithdrawal)
                        {

                            // tell the user they do not have the funds available for this amount of withdrawal
                            Console.WriteLine("I am sorry you do not have that amount of funds available");
                            Console.WriteLine("Please choose a number less than {0}", usersBankAccount.GetCheckingBalance().ToString("C"));

                            // re-catch the users input
                            withdrawalAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                            // again validating that it is a number that was input and not something else this has to be done
                            // in order to make sure the users newly entered amount is try parsed or the while loop will run forever
                            if (!decimal.TryParse(withdrawalAmount, out convertedWithdrawal))
                            {
                                // tell the user to enter a vaild number again
                                Console.WriteLine("Please enter a vaild number less than {0}", usersBankAccount.GetCheckingBalance().ToString("C"));
                                // re- catch the users input
                                withdrawalAmount = Console.ReadLine();
                                Console.WriteLine("\r\n");
                            }




                        }
                        // create a new decimal variable to perform the withdrawal with for the setter
                        decimal doTheWithdrawal;
                        doTheWithdrawal = usersBankAccount.GetCheckingBalance() - convertedWithdrawal;

                        // user the setter to change the bank account balance
                        usersBankAccount.SetCheckingAccountBalance(doTheWithdrawal);
                        Console.WriteLine("After your withdrawal of {0} your Checking Account balance is {1}.", convertedWithdrawal.ToString("C"), usersBankAccount.GetCheckingBalance().ToString("C"));
                        Console.WriteLine("Your Bank Account balance is {0}", usersBankAccount.GetBankBalance().ToString("C"));
                        Console.WriteLine("\r\n");

                    }





                }
                else if (usersConvertedResponse == 2)
                {
                    // we are going to be doing our Deposits here

                    

                    // create a new users choice variable
                    string usersChoice2;

                    // ask the users which account to perform the Deposit to
                    Console.WriteLine("Thank you which account would you like to perform the Deposit to?");
                    Console.WriteLine("Please choose the from the following choices");
                    Console.WriteLine("(1) for your Bank Account \r\n(2) for your Checking Account");

                    // catch the users input
                    usersChoice2 = Console.ReadLine();
                    Console.WriteLine("\r\n");

                    // new variable to hold the users second choice2 converted
                    int usersConvertedSecondChoice2;

                    // validate the users response
                    while (!int.TryParse(usersChoice2, out usersConvertedSecondChoice2) || !validChoices.Contains(usersConvertedSecondChoice2))
                    {

                        // this will run until the user has entered the correct response of 1 or 2
                        // notify the user that they have entered an incorrect value
                        Console.WriteLine("Please choose either option 1 for your Bank Account or option 2 for your Checking Account");

                        // re-catch the users input

                        usersChoice2 = Console.ReadLine();
                        // re-parsing the variable to make sure its updated
                        int.TryParse(usersChoice2, out usersConvertedSecondChoice2);
                        Console.WriteLine("\r\n");

                    }
                    // we can now do the math for a deposit on the Account that was chose
                    if (usersConvertedSecondChoice2 == 1)
                    {

                        // variable to store the deposit amount
                        string depositAmount;

                        // decimal variable to convert the depost amount with
                        decimal convertedDeposit;
                        // ask the user for the deposit amount
                        Console.WriteLine("What is the amount that you would like to Deposit?");

                        // catch the users response
                        depositAmount = Console.ReadLine();
                        Console.WriteLine("\r\n");

                        // validate the users response to make sure it is a number
                        while (!decimal.TryParse(depositAmount, out convertedDeposit))
                        {
                            // tell the users what went wrong
                            Console.WriteLine("Please enter a vaild numeric deposit amount and press RETURN");

                            // re-catch the users withdrawal amount
                            depositAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                        }

                        // do the actual math 

                        // create a new decimal variable to perform the deposit with for the setter
                        decimal doTheDeposit;
                        doTheDeposit = usersBankAccount.GetBankBalance() + convertedDeposit;

                        // user the setter to change the bank account balance
                        usersBankAccount.SetBankAccountBalance(doTheDeposit);
                        Console.WriteLine("After your deposit of {0} your Bank Account balance is {1}.", convertedDeposit.ToString("C"), usersBankAccount.GetBankBalance().ToString("C"));
                        Console.WriteLine("Your Checking Account balance is {0}", usersBankAccount.GetCheckingBalance().ToString("C"));
                        Console.WriteLine("\r\n");


                    }
                    if (usersConvertedSecondChoice2 == 2)
                    {

                        // variable to store the deposit amount
                        string depositAmount;

                        // decimal variable to convert the depost amount with
                        decimal convertedDeposit;
                        // ask the user for the deposit amount
                        Console.WriteLine("What is the amount that you would like to Deposit?");

                        // catch the users response
                        depositAmount = Console.ReadLine();
                        Console.WriteLine("\r\n");

                        // validate the users response to make sure it is a number
                        while (!decimal.TryParse(depositAmount, out convertedDeposit))
                        {
                            // tell the users what went wrong
                            Console.WriteLine("Please enter a vaild numeric deposit amount and press RETURN");

                            // re-catch the users withdrawal amount
                            depositAmount = Console.ReadLine();
                            Console.WriteLine("\r\n");

                        }

                        // do the actual math 

                        // create a new decimal variable to perform the deposit with for the setter
                        decimal doTheDeposit;
                        doTheDeposit = usersBankAccount.GetCheckingBalance() + convertedDeposit;

                        // user the setter to change the bank account balance
                        usersBankAccount.SetCheckingAccountBalance(doTheDeposit);
                        Console.WriteLine("After your deposit of {0} your Checking Account balance is {1}.", convertedDeposit.ToString("C"), usersBankAccount.GetCheckingBalance().ToString("C"));
                        Console.WriteLine("Your Bank Account balance is {0}", usersBankAccount.GetBankBalance().ToString("C"));
                        Console.WriteLine("\r\n");
                        Console.WriteLine("The total of both of your accounts together is {0}", usersBankAccount.GrandTotal().ToString("C"));



                    }




                }


            }





           

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warren_Joel_CustomClass
{
    class BankAccount
    {
        // declare our member variables
        string mUserName;
        decimal mBankAccountBalance;
        decimal mCheckingAccountBalance;


        // create our construction function
        public BankAccount(string _name, decimal _bankbalance, decimal _checkingBalance) {

            // set the values of our member variables using our parameter variables
            mUserName = _name;
            mBankAccountBalance = _bankbalance;
            mCheckingAccountBalance = _checkingBalance;

        }

        // Creating our getters 1 for each member variable
        public string GetName() {

            // set the return value to our member variable we are working with
            return mUserName;
        }

        public decimal GetBankBalance() {

            // set the return value to our member variable we are working with now
            return mBankAccountBalance;
        }

        public decimal GetCheckingBalance() {

            // set the return value to our member variable we are working with now
            return mCheckingAccountBalance;
        }

        // Creating our Setters 1 for each member variable
        public void SetUserName(string _name) {

            // set the value of our member variable based on the users input
            mUserName = _name;

        }

        public void SetBankAccountBalance(decimal _bankBalance) {

            // set the value of our member variable based on the users input
            mBankAccountBalance = _bankBalance;
        }

        public void SetCheckingAccountBalance(decimal _checkBalance) {

            // set the value of our member variable base on the users input
            mCheckingAccountBalance = _checkBalance;
        }

        // Create a custom method to total and return the bank and checking account balances
        public decimal GrandTotal() {

            // creating a variable to store the total of the two account and return them no parameters
            // are required because we are calculating using our member variables
            decimal GrandTotal = mBankAccountBalance + mCheckingAccountBalance;
            return GrandTotal;

        }
    }
}

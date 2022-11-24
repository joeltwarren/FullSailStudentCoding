using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// Customer must have the following fields - 
/// a CheckingAccount field for the customer’s account
/// a string field for the customer’s name
/// Customer needs a constructor that takes a string parameter
/// This parameter should be assigned to the appropriate field.

/// </summary>
namespace JoelWarren_CE_01
{
    class Customer
    {
        // variables for the object
        private CheckingAccount _checkingAccount;
        private string _customersName;

        // getters and setters for the objects variables
        public string GetCustomersName()
        {
            return _customersName;
        }

        // I removed this because it is un-needed but I left it for furture reference
        //public void SetCustomersName(string name)
        //{
        //    _customersName = name;
        //}

        public CheckingAccount GetCheckingAccount()
        {
            return _checkingAccount;
        }

        public decimal GetAccountBalance()
        {
            return _checkingAccount.GetAccountBalance();
        }

        public int GetAccountNumber()
        {
            return _checkingAccount.GetAccountNumber();
        }

        public void SetAccountBalance(decimal accountBalance)
        {
            _checkingAccount.SetAccountBalance(accountBalance);
        }

        public void SetCheckingAccount(CheckingAccount account)
        {
            _checkingAccount = account;
        }

        // constructor
        public Customer(string name)
        {
            _customersName = name;
        }
    }
}

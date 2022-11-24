using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Must have the following fields
/// <summary>
/// 
/// CheckingAccount must have the following fields -
/// a Decimal field for the account balance.
/// a int field for the account number.
/// Constructors
/// CheckingAccount needs a constructor that takes an int parameter and a decimal parameter
/// These parameters should be assigned to the appropriate fields.
/// 
/// </summary>


namespace JoelWarren_CE_01
{
    class CheckingAccount
    {
        // variables of the object
        private decimal _accountBalance;
        private int _accountNumber;

        // getters and setters of those variables
        public decimal GetAccountBalance()
        {
            return _accountBalance;
        }

        public void SetAccountBalance(decimal accountBalance)
        {
            _accountBalance = accountBalance;

        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }

        // un-needed commented out but left in the event that I want to refer to it later
        //public void SetAccountNumber(int accountNumber)
        //{
        //    _accountNumber = accountNumber;
        //}

        // constructor
        public CheckingAccount(int accountNumber, decimal accountBalance)
        {
            _accountNumber = accountNumber;
            _accountBalance = accountBalance;
        }
    }
}

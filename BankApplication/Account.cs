using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Represents a users bank account.
    /// </summary>
    class Account
    {
        private decimal accountBalance;

        /// <summary>
        /// Property for getting and setting the Account Balance.
        /// </summary>
        public decimal Balance
        {
            get => accountBalance;

            set
            {
                try
                {
                    if (value >= 0.0M)
                    {
                        accountBalance = value;
                    }
                    else
                    {
                        throw new Exception("The account balance cannot be negative.");
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Account()
        {

        }

        /// <summary>
        /// Constructor that sets the account balance.
        /// </summary>
        /// <param name="balance"></param>
        public Account(decimal balance)
        {
            Balance = balance;
        }

        /// <summary>
        /// Deposits money into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> Returns true or false based on the success of the operation. </returns>
        public virtual bool Credit(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }

            Balance += amount;
            return true;
        }

        /// <summary>
        /// Withdraws money from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> Returns true or false based on the success of the operation. </returns>
        public virtual bool Debit(decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Debit amount exceeded account balance.");
                return false;
            } 
            
            Balance -= amount;
            return true;
        }
    }
}

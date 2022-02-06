using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Represents a users savings account.
    /// </summary>
    class SavingsAccount : Account
    {
        private decimal interestRate;

        /// <summary>
        /// Property for getting and setting the Interest Rate.
        /// </summary>
        public decimal InterestRate
        {
            get => interestRate;

            set
            {
                if (value >= 0.0M)
                {
                    interestRate = value;
                }
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SavingsAccount()
        {

        }

        /// <summary>
        /// Constructor that sets the account balance and interest rate.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="rate"></param>
        public SavingsAccount(decimal balance, decimal rate)
        {
            Balance = balance;
            InterestRate = rate;
        }

        /// <summary>
        /// Calculates the interest on the money in the account.
        /// </summary>
        /// <returns> Returns the interest earned. </returns>
        public decimal CalculateInterest()
        {
            return Balance * InterestRate;
        }
    }
}

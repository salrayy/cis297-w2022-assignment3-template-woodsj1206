using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// Represents a users checkings account.
    /// </summary>
    class CheckingAccount : Account
    {
        private decimal chargedFee;

        /// <summary>
        /// Property for getting and setting the Charged Fee.
        /// </summary>
        public decimal ChargedFee
        {
            get => chargedFee;

            set
            {
                if (value >= 0.0M)
                {
                    chargedFee = value;
                }
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CheckingAccount()
        {

        }

        /// <summary>
        /// Constructor that sets the account balance and charged fee.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="fee"></param>
        public CheckingAccount(decimal balance, decimal fee)
        {
            Balance = balance;
            ChargedFee = fee;
        }

        /// <summary>
        /// Deposits money into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> Returns true or false based on the success of the operation. </returns>
        public override bool Credit(decimal amount)
        {
            if (base.Credit(amount))
            {
                Balance -= ChargedFee;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Withdraws money from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> Returns true or false based on the success of the operation. </returns>
        public override bool Debit(decimal amount)
        {
            if (base.Debit(amount))
            {
                Balance -= ChargedFee;
                return true;
            }
            return false;
        }
    }
}

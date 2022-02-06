using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// This program uses an Account hierachy to implement a banking application.
    /// </summary>
    /// <Student>Jonathan Woods</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    class Program
    {
        /// <summary>
        /// The program allows a user to deposit and withdraw from savings and checking accounts.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var accounts = new List<Account>() {new SavingsAccount(1000M, 0.05M), new CheckingAccount(300M, 5M), new SavingsAccount(1250M, 0.02M), new CheckingAccount(1500M, 3M) };

            int accountNumber = 0;
            string accountType;

            foreach (var currentAccount in accounts)
            {                
                accountNumber++;

                if (currentAccount is SavingsAccount)
                {
                    var account = (SavingsAccount)currentAccount;

                    accountType = "Savings";

                    UpdateAccount(account, accountNumber, accountType);

                    account.Credit(account.CalculateInterest());
                }
                else
                {
                    var account = (CheckingAccount)currentAccount;

                    accountType = "Checking";

                    UpdateAccount(account, accountNumber, accountType);
                }

                Console.WriteLine($"The updated balance of {accountType} Account #{accountNumber} is: ${currentAccount.Balance}\n");
            }

            Console.WriteLine("Press \"Enter\" to end the program.");

            Console.ReadLine();
        }

        /// <summary>
        /// Updates the balance of an account after the user withdraws or deposits money.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountType"></param>
        private static void UpdateAccount(Account account, int accountNumber, string accountType = "")
        {
            Console.WriteLine($"The current balance of {accountType} Account #{accountNumber} is: ${account.Balance}");

            Console.Write($"Enter the amount of money you would like to withdraw from {accountType} Account #{accountNumber}: $");

            if (decimal.TryParse(Console.ReadLine(), out decimal enteredAmount))
            {
                account.Debit(enteredAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }

            Console.Write($"Enter the amount of money you would like to deposit into {accountType} Account #{accountNumber}: $");

            if (decimal.TryParse(Console.ReadLine(), out enteredAmount))
            {
                account.Credit(enteredAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
    }
}
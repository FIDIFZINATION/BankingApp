using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.classes
{
    public class SavingsAccount : Account
    {
        public int MinimumBalance { get { return 500; } }

        public static void CreateSavingsAccount(int accountNumber)
        {
            SavingsAccount account = new SavingsAccount
            {
                AccountNumber = 0,
                AccountType = AccountTypeEnum.SAVINGS,
                Balance = 0
            };
            Console.WriteLine("Enter Initial Amount for your savings account: ");
            var balance = Console.ReadLine();

            if (!decimal.TryParse(balance, out decimal result) | result < account.MinimumBalance)
            {
                Console.WriteLine($"Amount can not be less than {account.MinimumBalance}.");
                return;
            }
            account.Balance = result;
            account.AccountNumber = accountNumber;
            Program.customer.AccountList.Add(account);
            Console.WriteLine("Savings account successfully created.");
            
        }
    }
}
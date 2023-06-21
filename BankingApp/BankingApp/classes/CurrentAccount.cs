using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.classes
{
    public class CurrentAccount : Account
    {
        public static void CreateCurrentAccount(int accountNumber)
        {
            SavingsAccount account = new SavingsAccount
            {
                AccountNumber = 0,
                AccountType = AccountTypeEnum.CURRENT,
                Balance = 0
            };
            Console.WriteLine("Enter Initial Amount for your current account: ");
            var balance = Console.ReadLine();

            if (!decimal.TryParse(balance, out decimal result))
            {
                Console.WriteLine($"Enter valid amount.");
                return;
            }
            account.Balance = result;
            account.AccountNumber = accountNumber;
            Program.customer.AccountList.Add(account);
            Console.WriteLine("Savings account successfully created.");

        }
    }
}

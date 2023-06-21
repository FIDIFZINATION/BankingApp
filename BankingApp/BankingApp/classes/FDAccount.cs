using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.classes
{
    public class FDAccount : Account
    {
        public decimal InterestRate { get; set; }
        public int MaturityPeriod { get; set; }

        public static void CreateFDAccount(int accountNumber)
        {
            FDAccount account = new FDAccount
            {
                AccountNumber = 0,
                AccountType = AccountTypeEnum.FD,
                Balance = 0
            };
            Console.WriteLine("Enter initial amount for your Fixed Deposit account: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Rate of Interest: ");
            decimal ROI = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter maturity Period (In Months): ");
            int maturityPeriod = Convert.ToInt32(Console.ReadLine());

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.MaturityPeriod = maturityPeriod;
            account.InterestRate = ROI;
            Program.customer.AccountList.Add(account);
            Console.WriteLine("Fixed Deposit account successfully created.");
        }

        public static void CloseFDAccount()
        {
            List<Account> FD = Program.ShowAccounts(AccountTypeEnum.FD.ToString());
            Console.WriteLine("Select Account to close: ");
            Account accountToClose = FD[Convert.ToInt32(Console.ReadLine()) - 1];

            List<Account> savingsAccounts = Program.ShowAccounts(AccountTypeEnum.SAVINGS.ToString());
            Console.WriteLine("Sellect Account to transfer funds: ");
            Account accountTotransfer = savingsAccounts[Convert.ToInt32(Console.ReadLine()) - 1];
            Program.customer.AccountList.Find(acc => acc.AccountNumber == accountTotransfer.AccountNumber).Balance += accountToClose.Balance;

            Program.customer.AccountList.Remove(accountToClose);
        }
    }

}

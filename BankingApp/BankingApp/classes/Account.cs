using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.classes
{
    public enum AccountTypeEnum
    {
        SAVINGS,
        CURRENT,
        FD
    }
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountTypeEnum AccountType { get; set; }

        public static void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("Select type of account: ");
            Console.WriteLine("1.\tSavings \n2.\tCurrent \n3.\tFixedDeposit \n0.\tExit");
            var userPrompt = Console.ReadLine();
            int selection;
            if (!int.TryParse(userPrompt, out selection))
            {
                Console.WriteLine("Invalid Option selected!!");
                return;
            }
            else
            {
                Random random = new Random();
                int accountNumber = random.Next();

                Console.WriteLine(accountNumber);
                switch (selection)
                {
                    case 0: return;
                    case 1: SavingsAccount.CreateSavingsAccount(accountNumber); break;
                    case 2: CurrentAccount.CreateCurrentAccount(accountNumber); break;
                    case 3: FDAccount.CreateFDAccount(accountNumber); break;
                }
            }
        }

        public static void Deposit()
        {
            Program.ShowAccounts();
            Console.WriteLine("Select account to deposit.");
            Account selectedAccount = Program.customer.AccountList[Convert.ToInt32(Console.ReadLine()) - 1];
            if (selectedAccount.AccountType == AccountTypeEnum.FD)
            {
                Console.WriteLine("Cannot deposit to Fixed Deposit account.");
                return;
            }

            Console.WriteLine($"Selected Account is : {selectedAccount.AccountNumber}");
            Console.WriteLine("\nEnter amount to deposit.");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            selectedAccount.Balance += amount;
            AddTransaction(selectedAccount.AccountNumber, amount, TransactionType.Deposit);
        }

        public static void Withdraw()
        {
            Program.ShowAccounts();
            Console.WriteLine("Select account to withdraw.");
            Account selectedAccount = Program.customer.AccountList[Convert.ToInt32(Console.ReadLine()) - 1];
            if (selectedAccount.AccountType == AccountTypeEnum.FD)
            {
                Console.WriteLine("Cannot withdraw from Fixed Deposit account.");
                return;
            }

            Console.WriteLine($"Selected Account is : {selectedAccount.AccountNumber}");
            Console.WriteLine("\nEnter amount to withdraw.");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (selectedAccount.AccountType == AccountTypeEnum.SAVINGS && selectedAccount.Balance - amount < 500)
            {
                return;
            }

            selectedAccount.Balance -= amount;
            AddTransaction(selectedAccount.AccountNumber, amount, TransactionType.Withdraw);
        }

        public static void Transfer()
        {
            Program.ShowAccounts();
            Console.WriteLine("Select account from which you want to transfer.");
            Account Payer = Program.customer.AccountList[Convert.ToInt32(Console.ReadLine()) - 1];
            Console.WriteLine($"Selected Payer Account : {Payer.AccountNumber}");

            Console.WriteLine("Select account to which you want to transfer.");
            Account Receiver = Program.customer.AccountList[Convert.ToInt32(Console.ReadLine()) - 1];
            Console.WriteLine($"Selected Receiver Account : {Receiver.AccountNumber}");

            if (Payer == Receiver)
            {
                Console.WriteLine("Cannot transfer funds to same account.");
                return;
            }
            if (Payer.AccountType == AccountTypeEnum.FD | Receiver.AccountType == AccountTypeEnum.FD)
            {
                Console.WriteLine("Cannot perfom transactions in Fixed Deposit account.");
                return;
            }

            Console.WriteLine("\nEnter amount to transfer.");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (Payer.AccountType == AccountTypeEnum.SAVINGS && Payer.Balance - amount < 500)
            {
                return;
            }

            Payer.Balance -= amount;
            Receiver.Balance += amount;

            Console.Clear();
            Console.WriteLine("Transfer Successfull!!.");
            AddTransaction(Payer.AccountNumber, amount, TransactionType.Withdraw);
            AddTransaction(Receiver.AccountNumber, amount, TransactionType.Deposit);
        }

        public static void AddTransaction(int ac, decimal amount, TransactionType type)
        {
            Transaction transaction = new Transaction
            {
                TransactionAccountNumber = ac,
                TransactionAmount = amount,
                TransactionType = type,
                TransactionDate = DateTime.Now
            };

            Program.customer.TransactionList.Add(transaction);
        }
    }
}

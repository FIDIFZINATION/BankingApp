using BankingApp.classes;
using Transaction = BankingApp.classes.Transaction;

namespace BankingApp
{
    public class Program
    {
        public static Customer customer = new Customer();
        static Random rand = new Random();
        static int customerId = rand.Next();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();
            customer.CustomerName = customerName;
            customer.CustomerId = customerId;
            customer.AccountList = new List<Account>();
            customer.TransactionList = new List<Transaction>();

            while (true)
            {
                Console.WriteLine("1.\tShow All Accounts " +
                                "\n2.\tCreateAccount " +
                                "\n3.\tDeposit " +
                                "\n4.\tWithdraw " +
                                "\n5.\tTransfer " +
                                "\n6.\tShow Transactions " +
                                "\n7.\tClose FD Account" +
                                "\n0.\tExit");
                var userPrompt = Console.ReadLine();

                switch (userPrompt)
                {
                    case "0":
                        return;

                    case "1":
                        ShowAccounts();
                        break;

                    case "2":
                        Account.CreateAccount();
                        break;

                    case "3":
                        Account.Deposit();
                        break;

                    case "4":
                        Account.Withdraw();
                        break;

                    case "5":
                        Account.Transfer();
                        break;

                    case "6":
                        ShowTransactions();
                        break;

                    case "7":
                        FDAccount.CloseFDAccount();
                        break;
                }
            }
        }

        public static List<Account> ShowAccounts(string ToShow = "All")
        {
            List<Account> AccountsToShow = new List<Account>();
            if (ToShow == "All")
            {
                AccountsToShow = customer.AccountList;
            }
            else
            {
                AccountsToShow = customer.AccountList.FindAll(account => account.AccountType.ToString() == ToShow);
            }

            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Sr.No",-15}  {"Account Number",10}  {"Account Type",30}  {"Balance",35}");
            int index = 0;
            AccountsToShow.ForEach((account) =>
            {
                Console.WriteLine($"{index + 1,-15}  {account.AccountNumber,10}  {account.AccountType,30}  {account.Balance,35}");
                index++;
            });
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            return AccountsToShow;
        }

        public static void ShowTransactions()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Sr.No",-15}  {"Account Number",10}  {"Transaction Type",30}  {"Transaction Amount",35}  {"Transaction Date",20}");
            int index = 0;
            customer.TransactionList.ForEach((transaction) =>
            {
                Console.WriteLine($"{index,-15}  {transaction.TransactionAccountNumber,10}  {transaction.TransactionType,25}  {transaction.TransactionAmount,29}  {transaction.TransactionDate,50}");
                index++;
            });
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
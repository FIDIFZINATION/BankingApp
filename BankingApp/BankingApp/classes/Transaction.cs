using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.classes
{
    public enum TransactionType
    {
        Deposit,
        Withdraw
    }
    public class Transaction
    {
        public int TransactionAccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

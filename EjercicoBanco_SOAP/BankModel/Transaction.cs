using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel
{
    public enum TransactionType
    {
        Received,
        Submitted,
        Null
    }
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public Transaction()
        {
            Date = DateTime.Now;
            TransactionType = TransactionType.Null;
        }
    }
}

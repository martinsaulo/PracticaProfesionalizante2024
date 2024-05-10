using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel
{
    public class BankAccount
    {
        public int AccountID { get; set; }
        public List<Transaction> TransactionHistory { get; protected set; }
        private int TransactionCount { get; set; } 
        public double Balance { get; protected set; }
        public Client AccountOwner { get; set; }
        public BankAccount()
        {
            TransactionCount = 0;
            Balance = 0;
            TransactionHistory =  new List<Transaction>();
        }

        public void RecordTransaction(Transaction newTransaction, TransactionType type)
        {
            int id = TransactionCount + 1;
            double amount = newTransaction.Amount;

            if (type == TransactionType.Null)
            {
                throw new ArgumentException("TransactionType cannot be Null.");
            }

            newTransaction.TransactionType = type;

            TransactionHistory.Add(newTransaction);
            TransactionCount++;

            if (type == TransactionType.Submitted)
            {
                Balance -= amount;
            }
            else
            {
                Balance += amount;
            }
        }
        public bool ReceiveNewTransaction(Transaction newTransaction)
        {
            if (newTransaction.Amount <= 0)
            {
                return false;
            }
            else
            {
                RecordTransaction(newTransaction, TransactionType.Received);
                return true;
            }
        }
        public void MakeNewTransaction(double amount, string description, int targetAccountID)
        {
            var targetAccount = Bank.BankAccounts.Find(x => x.AccountID == targetAccountID);

            if (targetAccount == null)
            {
                throw new Exception("Account not found.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("The amount cannot be negative or equal to zero.");
            }

            Transaction newTransaction = new Transaction()
            {
                TransactionID = this.AccountID,
                Amount = amount,
                Description = description,
            };

            bool transactionAccepted = targetAccount.ReceiveNewTransaction(newTransaction);

            if (transactionAccepted)
            {
                RecordTransaction(newTransaction, TransactionType.Submitted);
            }
            else
            {
                throw new Exception("Transaction denied.");
            }

        }
        public bool isDebtor()
        {
            return Balance < 0;
        }
    }
}

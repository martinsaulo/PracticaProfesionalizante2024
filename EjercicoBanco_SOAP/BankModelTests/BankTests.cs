using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel.Tests
{
    [TestClass()]
    public class BankTests
    {
        [TestInitialize]
        public void GetInitialArrenge()
        {
            Bank.AddNewClient("Jose Paz", "123456789");
            Bank.AddNewClient("Diego Gomez", "987654321");
            Bank.AddNewAccount(1);
            Bank.AddNewAccount(2);
        }

        [TestMethod()]
        public void AddNewClient_Test()
        {
            int expectedClientCount = Bank.ClientCount + 1;
            Bank.AddNewClient("New Client", "454543543");

            Assert.AreEqual(expectedClientCount, Bank.ClientCount);
        }

        [TestMethod()]
        public void AddNewAccount_Fail_Test()
        {
            var exception = Assert.ThrowsException<Exception>(() => Bank.AddNewAccount(0));

            Assert.AreEqual("Client not found.", exception.Message);
        }

        [TestMethod()]
        public void AddNewAccount_Ok_Test()
        {
            int expectedAccountCount = Bank.AccountCount + 1;
            Bank.AddNewAccount(1);

            Assert.AreEqual(expectedAccountCount, Bank.AccountCount);
        }

        [TestMethod()]
        public void RecordNewTransaction_Null_Test()
        {

            Transaction newTransaction = new Transaction()
            {
                TransactionID = 0,
                Amount = 1000,
                Description = "test descrip"
            };
            BankAccount targetAccount = Bank.BankAccounts[1];

            var exception = Assert.ThrowsException<ArgumentException>(() =>

            targetAccount.RecordTransaction(newTransaction, TransactionType.Null)

            );

            Assert.AreEqual("TransactionType cannot be Null.", exception.Message);
        }

        [TestMethod()]
        public void RecordNewTransaction_Received_Test()
        {

            Transaction newTransaction = new Transaction()
            {
                TransactionID = 0,
                Amount = 1000,
                Description = "test descrip"
            };
            BankAccount targetAccount = Bank.BankAccounts[1];
            double preBalance = targetAccount.Balance;

            targetAccount.RecordTransaction(newTransaction, TransactionType.Received);

            Assert.AreEqual(preBalance + 1000, targetAccount.Balance);
        }

        [TestMethod()]
        public void RecordNewTransaction_Submitted_Test()
        {

            Transaction newTransaction = new Transaction()
            {
                TransactionID = 0,
                Amount = 1000,
                Description = "test descrip"
            };
            BankAccount targetAccount = Bank.BankAccounts[1];
            double preBalance = targetAccount.Balance;

            targetAccount.RecordTransaction(newTransaction, TransactionType.Submitted);

            Assert.AreEqual(preBalance - 1000, targetAccount.Balance);
        }

        [TestMethod()]
        public void ReceiveTransaction_Accepted_Test()
        {
            BankAccount testAccount = Bank.BankAccounts.First();
            Transaction newTransaction = new Transaction()
            {
                TransactionID = 1,
                Amount = 1000,
                Description = "test descrip"
            };
            bool flag = testAccount.ReceiveNewTransaction(newTransaction);

            Assert.IsTrue(flag);
        }

        [TestMethod()]
        public void ReceiveTransaction_Denied_Test()
        {
            BankAccount testAccount = Bank.BankAccounts.First();
            Transaction newTransaction = new Transaction()
            {
                TransactionID = 1,
                Amount = -1000,
                Description = "test descrip"
            };
            bool flag = testAccount.ReceiveNewTransaction(newTransaction);

            Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void MakeNewTransaction_Ok_Test()
        {
            BankAccount sourceAccount = Bank.BankAccounts.First();
            BankAccount targetAccount = Bank.BankAccounts[1];

            sourceAccount.MakeNewTransaction(1000, "test descrip", 1);

        }

        [TestMethod()]
        public void MakeNewTransaction_NotFound_Test()
        {
            BankAccount sourceAccount = Bank.BankAccounts.First();
            BankAccount targetAccount = Bank.BankAccounts[1];

            var exception = Assert.ThrowsException<Exception>(
                () => sourceAccount.MakeNewTransaction(1000, "test descrip", -1)
            );

            Assert.AreEqual("Account not found.", exception.Message);
        }

        [TestMethod()]
        public void MakeNewTransaction_NegativeAmount_Test()
        {
            BankAccount sourceAccount = Bank.BankAccounts.First();
            BankAccount targetAccount = Bank.BankAccounts[1];

            var exception = Assert.ThrowsException<ArgumentException>(
                () => sourceAccount.MakeNewTransaction(-1000, "test descrip", 1)
            );

            Assert.AreEqual("The amount cannot be negative or equal to zero.", exception.Message);
        }

        [TestMethod()]
        public void CompleteTransaction_Ok_Test()
        {
            BankAccount sourceAccount = Bank.BankAccounts.First();
            BankAccount targetAccount = Bank.BankAccounts[1];
            double
                sourceBalance = sourceAccount.Balance,
                targetBalance = targetAccount.Balance;

            sourceAccount.MakeNewTransaction(1000, "test descrip", targetAccount.AccountID);

            Assert.AreEqual(sourceBalance - 1000, sourceAccount.Balance);
            Assert.AreEqual(targetBalance + 1000, targetAccount.Balance);
        }
    }
}
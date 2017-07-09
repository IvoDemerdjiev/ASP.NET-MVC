using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Controllers;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class TransactionControllerTests
    {
        [TestMethod]
        public void BalanceIsCorrectAfterDeposit()
        {
            //Arrange && Act
            var fakeDb = new FakeApplicationDbContext();
            fakeDb.CheckingAccounts = new FakeDbSet<CheckingAccount>();
            fakeDb.Transactions = new FakeDbSet<Transaction>();
            var checkingAccount = new CheckingAccount { Id = 1, AccountNumber = "0000000000", Balance = 0 };
            fakeDb.CheckingAccounts.Add(checkingAccount);
            var transactionController = new TransactionController(fakeDb);
            transactionController.Deposit(new Transaction { CheckingAccountId = 1, Amount = 100 });

            //Assert
            Assert.AreEqual(100, checkingAccount.Balance);
        }
    }
}

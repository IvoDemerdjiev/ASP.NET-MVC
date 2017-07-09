using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class CheckingAccountService
    {
        public IApplicationDbContext db;

        public CheckingAccountService(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateCheckingAccount(string firstName, string lastName, string userId, decimal initialBalance)
        {
            var accountNumber = (12345 + db.CheckingAccounts.Count()).ToString().PadLeft(10, '0');
            var chekingAccount = new CheckingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                Balance = initialBalance,
                AccountNumber = accountNumber,
                ApplicationUserId = userId
            };
            db.CheckingAccounts.Add(chekingAccount);
            db.SaveChanges();
        }

        public void UpdateBalance(int checkingAccountId)
        {
            var chekingAccount = db.CheckingAccounts.Where(c => c.Id == checkingAccountId).First();
            chekingAccount.Balance = db.Transactions.Where(c => c.CheckingAccountId == checkingAccountId).Sum(c => c.Amount);

            db.SaveChanges();
        }
    }
}
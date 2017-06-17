using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET_POC.Models;
using System.Data.Entity.Migrations;

namespace NET_POC.Migrations
{
    class FinancialAccountSeed : ISeed
    {
        public void SeedData(NET_POC.Models.DataContexts context)
        {
            var banque = new FinancialAccount
            {
                AccountName = "Banque Nationale",
                InitAmount = 1200,
                Currency = Currency.CAD,
                Type = AccountType.DEBITOR
            };
            context.FinancialAccounts.AddOrUpdate(b => b.AccountName, banque);
            context.SaveChanges();
        }
    }
}
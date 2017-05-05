namespace NET_POC.Migrations.EBContext
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;

    internal sealed class EBContextConfiguration : DbMigrationsConfiguration<NET_POC.Models.EBContext>
    {
        public EBContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\EBContext";
        }

        protected override void Seed(NET_POC.Models.EBContext context)
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

            var ebContext = DependencyResolver.Current.GetService<NET_POC.Models.EBIdentityContext>();
            var alexisUser = ebContext.Users.Single(u => u.UserName == "avalois");

            alexisUser.FinancialAccounts.Add(banque);
            ebContext.Users.AddOrUpdate(u => u.UserName, alexisUser);
            ebContext.SaveChanges();

            base.Seed(context);
        }
    }
}

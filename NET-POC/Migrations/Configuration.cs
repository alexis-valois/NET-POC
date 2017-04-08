namespace NET_POC.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NET_POC.Models.EBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
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

            var alexisUser = new EBUser
            {
                UserName = "avalois",
                Email = "alexis.valois@hotmail.com",
                FirstName = "Alexis",
                LastName = "Valois",
                //BCrypt Hash : alexis
                Password = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO"
            };
            alexisUser.FinancialAccounts.Add(banque);
            context.Users.AddOrUpdate(u => u.UserName, alexisUser);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

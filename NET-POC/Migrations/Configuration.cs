namespace NET_POC.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NET_POC.Entities.EBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NET_POC.Entities.EBContext context)
        {
            var adminRole = new EBAuthority { Role = RoleType.ADMIN };
            context.Authorities.AddOrUpdate(a => a.Role, adminRole);

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
                Username = "avalois",
                Email = "alexis.valois@hotmail.com",
                FirstName = "Alexis",
                LastName = "Valois",
                //BCrypt Hash : alexis
                Password = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO"
            };
            alexisUser.Authorities.Add(adminRole);
            alexisUser.FinancialAccounts.Add(banque);
            context.Users.AddOrUpdate(u => u.Username, alexisUser);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

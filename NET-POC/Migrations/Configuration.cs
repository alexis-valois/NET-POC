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
            context.SaveChanges();

            var adminRole = new EBRole
            {
                Name = "Admin",
            };

            context.Roles.AddOrUpdate(a => a.Name, adminRole);
            context.SaveChanges();

            var alexisUserRole = new EBUserRole();

            var alexisUser = new EBUser
            {
                UserName = "avalois",
                Email = "alexis.valois@hotmail.com",
                FirstName = "Alexis",
                LastName = "Valois",
                //BCrypt Hash : alexis
                PasswordHash = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO"
            };
            alexisUser.FinancialAccounts.Add(banque);
            alexisUser.Roles.Add(alexisUserRole);
            context.Users.AddOrUpdate(u => u.UserName, alexisUser);
            context.SaveChanges();

            alexisUserRole.UserId = alexisUser.Id;
            alexisUserRole.RoleId = adminRole.Id;

            //context.UserRoles.AddOrUpdate(alexisUserRole);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}

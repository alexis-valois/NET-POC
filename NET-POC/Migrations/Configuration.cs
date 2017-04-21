namespace NET_POC.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;

    internal sealed class ConfigurationIdentityContext : DbMigrationsConfiguration<NET_POC.Models.EBIdentityContext>
    {
        public ConfigurationIdentityContext()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NET_POC.Models.EBIdentityContext context)
        {
            var adminRole = new IdentityRole()
            {
                Name = "Admin"
            };

            context.Roles.AddOrUpdate(a => a.Name, adminRole);
            context.SaveChanges();

            var alexisUserRole = new IdentityUserRole();

            var alexisUser = new EBUser
            {
                UserName = "avalois",
                Email = "alexis.valois@hotmail.com",
                FirstName = "Alexis",
                LastName = "Valois",
                //BCrypt Hash : alexis
                PasswordHash = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO"
            };

            alexisUserRole.UserId = alexisUser.Id;
            alexisUserRole.RoleId = adminRole.Id;
            alexisUser.Roles.Add(alexisUserRole);

            context.Users.AddOrUpdate(u => u.UserName, alexisUser);
            context.SaveChanges();
        }

        internal sealed class ConfigurationEBContext : DbMigrationsConfiguration<NET_POC.Models.EBContext>
        {
            public ConfigurationEBContext()
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

                //var adminRole = new IdentityRole()
                //{
                //    Name = "Admin"
                //};

                //context.Roles.AddOrUpdate(a => a.Name, adminRole);
                //context.SaveChanges();

                //var alexisUserRole = new IdentityUserRole();

                //var alexisUser = new EBUser
                //{
                //    UserName = "avalois",
                //    Email = "alexis.valois@hotmail.com",
                //    FirstName = "Alexis",
                //    LastName = "Valois",
                //    //BCrypt Hash : alexis
                //    PasswordHash = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO"
                //};
                var ebContext = DependencyResolver.Current.GetService<NET_POC.Models.EBIdentityContext>();
                var alexisUser = ebContext.Users.Single(u => u.UserName == "alexis");


                alexisUser.FinancialAccounts.Add(banque);
                context.Users.AddOrUpdate(u => u.UserName, alexisUser);
                context.SaveChanges();

                base.Seed(context);
            }
        }

    }
}

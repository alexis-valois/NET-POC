using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NET_POC.Entities
{
    public class EBContext : DbContext
    {
        public DbSet<EBUser> Users { get; set; }
        public DbSet<EBAuthority> Authorities { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }

        static EBContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EBContext, Configuration>());
            using (EBContext db = new EBContext())
                db.Database.Initialize(false);
        }

    }

    public class Configuration : DbMigrationsConfiguration<EBContext>
    {
        private readonly bool pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            var migrator = new DbMigrator(this);
            pendingMigrations = migrator.GetPendingMigrations().Any();

            if (pendingMigrations)
            {
                migrator.Update();
                Seed(new EBContext());
            }
        }

        protected override void Seed(EBContext context)
        {
            var adminAuthority = new EBAuthority();
            adminAuthority.Role = RoleType.ADMIN;
            adminAuthority.EBAuthorityID = 1;

            context.Authorities.AddOrUpdate(adminAuthority);

            var banque = new FinancialAccount();
            banque.AccountName = "Banque Nationale";
            banque.InitAmount = 0;
            banque.Currency = Currency.CAD;
            banque.Type = AccountType.DEBITOR;

            context.FinancialAccounts.AddOrUpdate(banque);

            var alexisUser = new EBUser();
            alexisUser.Authorities.Add(adminAuthority);
            alexisUser.EBUserID = 1;
            alexisUser.Username = "avalois";
            alexisUser.Email = "alexis.valois@hotmail.com";
            alexisUser.FirstName = "Alexis";
            alexisUser.LastName = "Valois";
            alexisUser.FinancialAccounts.Add(banque);

            //BCrypt Hash : alexis
            alexisUser.Password = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO";

            context.Users.AddOrUpdate(alexisUser);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
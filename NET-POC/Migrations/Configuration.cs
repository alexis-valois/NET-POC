namespace NET_POC.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Practices.Unity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EBContext context)
        {
            // Impossible d'utiliser l'injection de dépendance dans une migration.
            GlobalSeeder seeder = new GlobalSeeder();
            seeder.SeedDatabase(context);
            base.Seed(context);
        }
    }
}

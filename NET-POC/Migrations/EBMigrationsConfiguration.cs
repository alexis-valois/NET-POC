namespace NET_POC.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;

    class EBMigrationsConfiguration : DbMigrationsConfiguration<NET_POC.Models.DataContexts>
    {
        public EBMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NET_POC.Models.DataContexts context)
        {
            GlobalSeeder seeder = new GlobalSeeder();
            seeder.SeedDatabase(context);
            base.Seed(context);
        }
    }
}

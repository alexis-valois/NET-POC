namespace NET_POC.Migrations.EBIdentityContext
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class EBIdentityConfiguration : DbMigrationsConfiguration<NET_POC.Models.EBIdentityContext>
    {
        public EBIdentityConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\EBIdentityContext";
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
    }
}

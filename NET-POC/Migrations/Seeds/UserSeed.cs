using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NET_POC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace NET_POC.Migrations
{
    [DependsOn(typeof(FinancialAccountSeed))]
    class UserSeed : ISeed
    {
        public void SeedData(EBContext context)
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

            var banque = context.FinancialAccounts.First();

            alexisUser.FinancialAccounts.Add(banque);
            context.Users.AddOrUpdate(u => u.UserName, alexisUser);
            context.SaveChanges();
        }
    }
}
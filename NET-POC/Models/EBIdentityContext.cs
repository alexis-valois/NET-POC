using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NET_POC.Models
{
    public class EBIdentityContext :
           IdentityDbContext<EBUser,
                             IdentityRole,
                             string,
                             IdentityUserLogin,
                             IdentityUserRole,
                             IdentityUserClaim>
    {
        public EBIdentityContext() : base("NET_POC.Entities.EBContext") { }

        override protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id).HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().HasKey(r => new { r.Id, r.UserId });
            modelBuilder.Entity<EBUser>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EBUser>().HasMany(p => p.Logins).WithRequired().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EBUser>().HasMany(p => p.Claims).WithRequired().HasForeignKey(p => p.UserId);

            modelBuilder.Ignore<FinancialAccount>();
        }
    }
}
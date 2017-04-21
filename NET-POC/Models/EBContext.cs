using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public class EBContext : DbContext
    {
        public EBContext() : base("NET_POC.Entities.EBContext") { }

        public DbSet<EBUser> Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        //public DbSet<IdentityUserRole> UserRoles { get; set; }

        //override protected void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        //    modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id).HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //    modelBuilder.Entity<IdentityUserClaim>().HasKey(r => new { r.Id, r.UserId });
        //    modelBuilder.Entity<EBUser>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
        //    modelBuilder.Entity<EBUser>().HasMany(p => p.Logins).WithRequired().HasForeignKey(p => p.UserId);
        //    modelBuilder.Entity<EBUser>().HasMany(p => p.Claims).WithRequired().HasForeignKey(p => p.UserId);
        //}
    }

    public class EBIdentityContext :
        IdentityDbContext<EBUser,
                          IdentityRole,
                          string,
                          IdentityUserLogin,
                          IdentityUserRole,
                          IdentityUserClaim>
    {
        public EBIdentityContext() : base("NET_POC.Entities.EBContext") { }

        //public DbSet<IdentityRole> Roles { get; set; }
        //public DbSet<IdentityUserRole> UserRoles { get; set; }

        override protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id).HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().HasKey(r => new { r.Id, r.UserId });
            modelBuilder.Entity<EBUser>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EBUser>().HasMany(p => p.Logins).WithRequired().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<EBUser>().HasMany(p => p.Claims).WithRequired().HasForeignKey(p => p.UserId);
        }

        //public static EBIdentityContext Create()
        //{
        //    return new EBIdentityContext();
        //}

    }
}
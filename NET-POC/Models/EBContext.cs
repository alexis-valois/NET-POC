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

        public virtual DbSet<EBUser> Users { get; set; }
        public virtual DbSet<FinancialAccount> FinancialAccounts { get; set; }

        override protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityUserRole>();
            modelBuilder.Ignore<IdentityUserClaim>();
            modelBuilder.Entity<EBUser>().ToTable("EBUsers");
            modelBuilder.Entity<EBUser>().HasMany(u => u.FinancialAccounts).WithMany(f => f.Owners);
        }
    }
}
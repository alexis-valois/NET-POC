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
        public DbSet<EBUser> Users { get; set; }
        public DbSet<EBRole> Roles { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        //public DbSet<EBUserRole> UserRoles { get; set; }
        //public DbSet<EBUserLogin> UserLogins { get; set; }
        //public DbSet<EBUserClaim> UserClaims { get; set; }
    }
    
    public class EBIdentityContext : IdentityDbContext<EBUser,EBRole,int,EBUserLogin,EBUserRole, EBUserClaim>
    {
        public EBIdentityContext() : base("NET_POC.Entities.EBContext") { }
        
        public static EBIdentityContext Create()
        {
            return new EBIdentityContext();
        }

    }    
}
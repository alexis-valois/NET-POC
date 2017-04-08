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
        public DbSet<EBRole> Authorities { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
    }
    
    public class EBIdentityContext : IdentityDbContext<EBUser,EBRole,int,EBUserLogin,EBUserRole, EBUserClaim>
    {
        public EBIdentityContext() : base("DefaultConnection") { }

        public static EBIdentityContext Create()
        {
            return new EBIdentityContext();
        }

    }    
}
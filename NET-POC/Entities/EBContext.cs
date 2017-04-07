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
    }  
    
      
}
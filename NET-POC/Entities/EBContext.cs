using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET_POC.Entities
{
    public class EBContext : DbContext
    {
        public DbSet<EBUser> Users { get; set; }
        public DbSet<EBAuthority> Authorities { get; set; }

        static EBContext()
        {
            Database.SetInitializer<EBContext>(new EBDatabaseInitializer());
            using (EBContext db = new EBContext())
                db.Database.Initialize(false);
        }
    }

    class EBDatabaseInitializer : DropCreateDatabaseAlways<EBContext>
    {
        protected override void Seed(EBContext context)
        {
            var adminBase = new BaseEBEntity();
            var adminAuthority = new EBAuthority(adminBase);
            adminAuthority.Role = RoleType.ADMIN;
            var alexisBase = new BaseEBEntity();
            var alexisUser = new EBUser(alexisBase, adminAuthority);
            alexisUser.Email = "alexis.valois@hotmail.com";
            alexisUser.FirstName = "Alexis";
            alexisUser.LastName = "Valois";

            //BCrypt Hash : alexis
            alexisUser.Password = "$2a$12$cT1IEyGkt1F.PuAQZvLOJ.WNEVdQ0VW4E8SjeBDWWs3d5BgCsYhoO";

            context.Users.Add(alexisUser);

            base.Seed(context);
        }
    }
}
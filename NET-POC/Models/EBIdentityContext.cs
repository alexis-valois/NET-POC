using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NET_POC.Models
{
    public class EBIdentityDbContext : IdentityDbContext
    {
        public EBIdentityDbContext() : base("NET_POC.Entities.EBContext") { }

        public static EBIdentityDbContext Create()
        {
            return new EBIdentityDbContext();
        }
    }
}
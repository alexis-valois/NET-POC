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
    public class EBUser : 
        IdentityUser, 
        IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        public string ActivationToken { get; set; }

        public string CreationTimezone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public bool Enabled { get; set; } = false;

        public DateTime? LastLoginUtc { get; set; }

        public DateTime? LastLogoutUtc { get; set; }

        [Required]
        public bool CredentialsExpired { get; set; } = false;

        [Required]
        public bool AccountExpired { get; set; } = false;

        public virtual ICollection<FinancialAccount> FinancialAccounts { get; set; } = new List<FinancialAccount>();

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.UserName);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<EBUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
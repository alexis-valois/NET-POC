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

namespace NET_POC.Entities
{
    public class EBUser : IdentityUser, IEBEntity
    {
        public BaseEBEntity BaseEntity { get; } = new BaseEBEntity();

        [Key]
        [Index]
        public long EBUserID { get; set; }

        [Index("IX_Username", IsUnique = true)]
        [Required]
        public string Username { get; set; }

        //[Index]
        //[Index("IX_Email", IsUnique = true)]
        //[Required]
        //public string Email { get; set; }

        public string ActivationToken { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        [Required]
        public bool Enabled { get; set; } = false;

        public DateTime? LastLogin { get; set; }

        public string LastLoginTimezone { get; set; }

        public DateTime? LastLogout { get; set; }

        public string LastLogoutTimezone { get; set; }

        [Required]
        public bool Locked { get; set; } = false;

        [Required]
        public bool CredentialsExpired { get; set; } = false;

        [Required]
        public bool AccountExpired { get; set; } = false;

        public virtual ICollection<EBAuthority> Authorities { get; set; } = new List<EBAuthority>();

        public virtual ICollection<FinancialAccount> FinancialAccounts { get; set; } = new List<FinancialAccount>();

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.Username);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<EBUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
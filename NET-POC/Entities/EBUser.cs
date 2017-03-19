using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_POC.Entities
{
    public class EBUser : IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        [Key]
        [Index]
        public long EBUserID { get; set; }

        [Index]
        [Required]
        public string Username { get; set; }

        [Index]
        [Required]
        public string Email { get; set; }

        public string ActivationToken { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Password { get; set; }
        
        public bool Enabled { get; set; }

        public DateTime LastLogin { get; set; }

        public string LastLoginTimezone { get; set; }

        public DateTime LastLogout { get; set; }

        public string LastLogoutTimezone { get; set; }

        public bool Locked { get; set; }

        public bool CredentialsExpired { get; set; }

        public bool AccountExpired { get; set; }

        public virtual ICollection<EBAuthority> Authorities { get; set; } = new List<EBAuthority>();
        
        public EBUser(BaseEBEntity baseEntity, ICollection<EBAuthority> authorities)
        {
            BaseEntity = baseEntity;
            Authorities = authorities;
        }

        public EBUser(BaseEBEntity baseEntity, EBAuthority authoritie)
        {
            BaseEntity = baseEntity;
            Authorities.Add(authoritie);
        }

        public EBUser() { }

        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.Username);
            }
        }
    }
}
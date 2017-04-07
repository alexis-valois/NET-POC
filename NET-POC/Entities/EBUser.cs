﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace NET_POC.Entities
{
    public class EBUser : IUser, IEBEntity
    {
        public BaseEBEntity BaseEntity { get; } = new BaseEBEntity();

        [Key]
        [Index]
        public string Id { get; set; }

        [Index("IX_Username", IsUnique = true)]
        [Required]
        public string UserName { get; set; }

        [Index]
        [Index("IX_Email", IsUnique = true)]
        [Required]
        public string Email { get; set; }

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
                return string.IsNullOrEmpty(this.UserName);
            }
        }
    }
}
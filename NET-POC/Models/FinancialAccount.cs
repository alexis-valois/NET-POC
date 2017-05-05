using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public enum AccountType { CREDITOR, DEBITOR };
    public enum Currency { CAD, USD};

    public class FinancialAccount : IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        [Key]
        [Index]
        public string Id { get; set; }

        [Required]
        public AccountType Type { get; set; } = AccountType.DEBITOR;

        [Required]
        [Index]
        public string AccountName { get; set; }

        public decimal InitAmount { get; set; } = 0;

        public Currency Currency { get; set; } = Currency.CAD;

        public virtual ICollection<EBUser> Owners { get; set; } = new List<EBUser>();
        
        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(AccountName);
            }
        }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public class EBRole : IdentityRole<int, EBUserRole>, IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        [Key]
        [Index]
        public long EBAuthorityID { get; set; }

        public virtual ICollection<EBUser> AssociatedUsers { get; set; } = new List<EBUser>();

        public bool IsEmpty
        {
            get
            {
                return EBAuthorityID == 0;
            }
        }
    }
}
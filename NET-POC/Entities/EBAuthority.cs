using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_POC.Entities
{
    public enum RoleType { USER, ADMIN };

    public class EBAuthority : IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        [Key]
        [Index]
        public long EBAuthorityID { get; set; }

        [Required]
        public RoleType Role { get; set; }

        public virtual ICollection<EBUser> AssociatedUsers { get; set; } = new List<EBUser>();

        public EBAuthority(BaseEBEntity baseEntity)
        {
            BaseEntity = baseEntity;
        }

        public EBAuthority() { }

        public bool IsEmpty
        {
            get
            {
                return EBAuthorityID == 0;
            }
        }
    }
}
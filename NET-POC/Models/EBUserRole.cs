using Microsoft.AspNet.Identity.EntityFramework;
using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public class EBUserRole : IdentityUserRole<int>, IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        [Key]
        public int UserRoleId { get; set; }

        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
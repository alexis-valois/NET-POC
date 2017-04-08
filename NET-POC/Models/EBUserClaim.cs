using Microsoft.AspNet.Identity.EntityFramework;
using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public class EBUserClaim : IdentityUserClaim<int>, IEBEntity
    {
        public BaseEBEntity BaseEntity { get; set; } = new BaseEBEntity();

        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
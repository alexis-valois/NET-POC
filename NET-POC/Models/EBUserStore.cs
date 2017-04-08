using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace NET_POC.Models
{
    public class EBUserStore : 
        UserStore<EBUser,EBRole,int,EBUserLogin,EBUserRole, EBUserClaim>, 
        IUserStore<EBUser>, 
        IDisposable
    {
        public EBUserStore(EBIdentityDbContext context) : base(context) { }

        public Task<EBUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
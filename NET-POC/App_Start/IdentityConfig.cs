using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC.App_Start
{
    public class EBUserManager : UserManager<EBUser>
    {
        public EBUserManager(IUserStore<EBUser> store)
            : base(store)
        {
        }

        public static EBUserManager Create(IdentityFactoryOptions<EBUserManager> options, IOwinContext context)
        {
            var manager = new EBUserManager(new EBUserStore(context.Get<EBIdentityDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<EBUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<EBUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NET_POC.App_Start;
using NET_POC.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(EBIdentityContext.Create);
            app.CreatePerOwinContext<EBUserManager>(EBUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("Account/Login")
                }
            );
        }
    }
}
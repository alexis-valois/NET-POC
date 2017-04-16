using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using NET_POC.App_Start;
using NET_POC.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_POC
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.CreatePerOwinContext(EBIdentityContext.Create);
            //app.CreatePerOwinContext<EBUserManager>(EBUserManager.Create);
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<UserManager<EBUser,string>>());
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<EBIdentityContext>());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("Account/Login")
                }
            );
        }
    }
}
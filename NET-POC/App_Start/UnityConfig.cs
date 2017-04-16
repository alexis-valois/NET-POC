using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using NET_POC.Services;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NET_POC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NET_POC.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        private static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<IEncryptionService>(new BCryptEncryptionService(int.Parse(appSettings.Get("BCryptCostParam") )) );
            container.RegisterInstance(new UserManager<EBUser, string>(new UserStore<EBUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(new EBIdentityDbContext())));
        }


        internal static void RegisterDependencyResolver(HttpConfiguration config)
        {
            var container = new UnityContainer();
            UnityConfig.RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NET_POC.Startup))]
namespace NET_POC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

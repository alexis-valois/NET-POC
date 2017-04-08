using Microsoft.Owin;
using Owin;
using NET_POC.App_Start;

[assembly: OwinStartup(typeof(NET_POC.Startup))]
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

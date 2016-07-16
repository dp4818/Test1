using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(P_NW.Startup))]
namespace P_NW
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

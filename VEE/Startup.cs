using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VEE.Startup))]
namespace VEE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

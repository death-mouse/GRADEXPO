using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GRADEXPO.Startup))]
namespace GRADEXPO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

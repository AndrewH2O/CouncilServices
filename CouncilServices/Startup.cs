using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CouncilServices.Startup))]
namespace CouncilServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

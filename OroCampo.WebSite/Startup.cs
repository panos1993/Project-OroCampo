using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OroCampo.WebSite.Startup))]
namespace OroCampo.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

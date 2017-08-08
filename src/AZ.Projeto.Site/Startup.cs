using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AZ.Projeto.Site.Startup))]
namespace AZ.Projeto.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

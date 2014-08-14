using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniPuan.Web.Startup))]
namespace UniPuan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

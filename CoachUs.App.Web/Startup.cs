using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoachUs.App.Web.Startup))]
namespace CoachUs.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_TestApp.Startup))]
namespace MVC_TestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

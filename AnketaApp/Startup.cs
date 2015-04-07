using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnketaApp.Startup))]
namespace AnketaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

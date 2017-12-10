using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationName.Startup))]
namespace ApplicationName
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

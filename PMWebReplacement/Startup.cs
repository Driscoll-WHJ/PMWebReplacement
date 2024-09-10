using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMWebReplacement.Startup))]
namespace PMWebReplacement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

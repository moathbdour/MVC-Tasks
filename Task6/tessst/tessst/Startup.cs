using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tessst.Startup))]
namespace tessst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

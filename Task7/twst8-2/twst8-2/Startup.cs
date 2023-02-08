using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(twst8_2.Startup))]
namespace twst8_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

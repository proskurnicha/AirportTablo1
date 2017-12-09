using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirportTablo1.Startup))]
namespace AirportTablo1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

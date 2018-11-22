using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyectopeli2.Startup))]
namespace Proyectopeli2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

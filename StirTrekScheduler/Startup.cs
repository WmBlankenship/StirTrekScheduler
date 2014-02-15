using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StirTrekScheduler.Startup))]
namespace StirTrekScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

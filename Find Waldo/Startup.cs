using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Find_Waldo.Startup))]
namespace Find_Waldo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

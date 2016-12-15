using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proactive.Startup))]
namespace Proactive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}

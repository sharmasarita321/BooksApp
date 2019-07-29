using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBookAssignment.Startup))]
namespace MVCBookAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

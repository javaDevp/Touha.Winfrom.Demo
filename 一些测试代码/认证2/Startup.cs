using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(认证2.Startup))]
namespace 认证2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

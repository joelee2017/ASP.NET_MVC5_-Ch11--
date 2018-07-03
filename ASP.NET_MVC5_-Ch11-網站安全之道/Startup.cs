using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.NET_MVC5__Ch11_網站安全之道.Startup))]
namespace ASP.NET_MVC5__Ch11_網站安全之道
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

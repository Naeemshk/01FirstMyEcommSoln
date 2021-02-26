using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyEcommShop.WebUI.Startup))]
namespace MyEcommShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

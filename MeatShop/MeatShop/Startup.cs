using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeatShop.Startup))]
namespace MeatShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.WebPage.Startup))]
namespace UI.WebPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

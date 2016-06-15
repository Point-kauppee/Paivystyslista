using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paivystyslista.Startup))]
namespace Paivystyslista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

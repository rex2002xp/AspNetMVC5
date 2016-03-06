using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionWebBase.Startup))]
namespace AplicacionWebBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

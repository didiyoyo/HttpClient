using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HttpClientServer.Startup))]
namespace HttpClientServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

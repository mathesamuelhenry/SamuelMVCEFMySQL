using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFMVCTestMySQL.Startup))]
namespace EFMVCTestMySQL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

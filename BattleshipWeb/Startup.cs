using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BattleshipWeb.Startup))]
namespace BattleshipWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}

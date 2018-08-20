using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BasketGraphQLAPI.Startup))]

namespace BasketGraphQLAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
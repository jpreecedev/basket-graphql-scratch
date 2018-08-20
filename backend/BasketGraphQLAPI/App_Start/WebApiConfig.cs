using System.Web.Http;
using System.Web.Http.Cors;

namespace BasketGraphQLAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var bootstrapper = new Bootstrapper();
            config.DependencyResolver = bootstrapper.Resolver();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}
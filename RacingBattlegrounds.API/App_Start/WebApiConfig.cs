using System.Web.Http;

namespace RacingBattlegrounds.API
{
    /// <summary>
    /// API Configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register Configurations
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

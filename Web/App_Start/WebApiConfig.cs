using System.Web.Http;

namespace Web
{
    /// <summary>
    /// Web API Configuration class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Default route name
        /// </summary>
        private const string DefaultRouteName = "DefaultApi";

        /// <summary>
        /// Default route template
        /// </summary>
        private const string DefaultRouteTempate = "api/{controller}/{id}";

        /// <summary>
        /// Register Web API
        /// </summary>
        /// <param name="httpConfiguration">Configuration of HttpServer instances</param>
        public static void Register(HttpConfiguration httpConfiguration)
        {
            if (httpConfiguration != null)
            {
                httpConfiguration.MapHttpAttributeRoutes();

                httpConfiguration.Routes.MapHttpRoute(
                    name: DefaultRouteName,
                    routeTemplate: DefaultRouteTempate,
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
}

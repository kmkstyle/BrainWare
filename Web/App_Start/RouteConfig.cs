using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    /// <summary>
    /// Route configuration class
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Ignore route url
        /// </summary>
        private const string IgnoreRouteUrl = "{resource}.axd/{*pathInfo}";

        /// <summary>
        /// Default route name
        /// </summary>
        private const string DefaultRouteName = "Default";

        /// <summary>
        /// Default route url
        /// </summary>
        private const string DefaultRouteUrl = "{controller}/{action}/{id}";

        /// <summary>
        /// Default route controller
        /// </summary>
        private const string DefaultRouteController = "Home";

        /// <summary>
        /// Default route action
        /// </summary>
        private const string DefaultRouteAction = "Index";

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routes">Routes</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            if (routes != null)
            {
                routes.IgnoreRoute(IgnoreRouteUrl);

                routes.MapRoute(
                    name: DefaultRouteName,
                    url: DefaultRouteUrl,
                    defaults: new { controller = DefaultRouteController, action = DefaultRouteAction, id = UrlParameter.Optional }
                );
            }
        }
    }
}

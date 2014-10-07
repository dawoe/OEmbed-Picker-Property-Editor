namespace Dawoe.EmbedPropertyEditor.Events
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The route config.
    /// </summary>
    internal class RouteConfig
    {
        /// <summary>
        /// Register custom routes
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Dawoe.EmbedPropertyEditor",
                url: "App_Plugins/DawoeEmbedPropertyEditor/{action}/{filename}",
                defaults: new { controller = "EmbeddedResource", action = "Resource", filename = UrlParameter.Optional });
        }
    }
}

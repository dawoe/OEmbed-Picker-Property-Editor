namespace Dawoe.OEmbedPickerPropertyEditor.Events
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
                name: Constants.PropertyEditorAlias,
                url: string.Format("{0}/{{action}}/{{filename}}", Constants.ResourceFolder),
                defaults: new
                              {
                                  controller = "EmbeddedResource", action = "Resource", filename = UrlParameter.Optional,
                              },
                namespaces: new[] { "Dawoe.OEmbedPickerPropertyEditor.Controllers" });
        }
    }
}

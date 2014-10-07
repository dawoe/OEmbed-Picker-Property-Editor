namespace Dawoe.EmbedPropertyEditor.Events
{
    using System.Web.Routing;

    using Umbraco.Core;

    /// <summary>
    /// Registration of umbraco event handlers
    /// </summary>
    internal class Registration : ApplicationEventHandler
    {
        /// <summary>
        /// The application started.
        /// </summary>
        /// <param name="umbracoApplication">
        /// The umbraco application.
        /// </param>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

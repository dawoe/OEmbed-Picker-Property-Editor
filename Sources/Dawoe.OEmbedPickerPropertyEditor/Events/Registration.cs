namespace Dawoe.OEmbedPickerPropertyEditor.Events
{
    using Umbraco.Core;
    using Umbraco.Core.Services;

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
            var clientSetup = new ClientSetup();
            clientSetup.Configure();                       
        }        
    }
}

namespace Dawoe.OEmbedPickerPropertyEditor.Events
{
    using System.Web.Routing;

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
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataTypeService.Saved += this.DataTypeServiceSaved;
            DataTypeService.Deleted += this.DataTypeServiceDeleted;
        }

        /// <summary>
        /// The data type service deleted event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DataTypeServiceDeleted(IDataTypeService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IDataTypeDefinition> e)
        {            
            Caching.RemoveFromDatatypesFromCache(e.DeletedEntities);
        }

        /// <summary>
        /// The data type service saved event handler
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DataTypeServiceSaved(IDataTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IDataTypeDefinition> e)
        {
            Caching.RemoveFromDatatypesFromCache(e.SavedEntities);
        }
    }
}

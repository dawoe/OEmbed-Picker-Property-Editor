namespace Dawoe.OEmbedPickerPropertyEditor.Events
{
    using System.Collections.Generic;

    using Dawoe.OEmbedPickerPropertyEditor.Caching;

    using Umbraco.Core;
    using Umbraco.Core.Models;

    using Constants = Dawoe.OEmbedPickerPropertyEditor.Constants;

    /// <summary>
    /// Caching events
    /// </summary>
    internal class Caching
    {
        /// <summary>
        /// The remove from datatypes from cache.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        public static void RemoveFromDatatypesFromCache(IEnumerable<IDataTypeDefinition> entities)
        {
            entities.ForEach(
                x =>
                    {
                        if (x.PropertyEditorAlias == Constants.PropertyEditorAlias)
                        {
                            CacheManager.Remove(string.Format("Dawoe.EmbedPropertyEditor.AllowMultiple_{0}", x.Id));
                        }
                    });
        }
    }
}

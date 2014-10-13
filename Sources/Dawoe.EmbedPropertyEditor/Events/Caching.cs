namespace Dawoe.EmbedPropertyEditor.Events
{
    using System.Collections.Generic;

    using Dawoe.EmbedPropertyEditor.Caching;

    using Umbraco.Core;
    using Umbraco.Core.Models;

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
                x => CacheManager.Remove(string.Format("Dawoe.EmbedPropertyEditor.AllowMultiple_{0}", x.Id)));
        }
    }
}

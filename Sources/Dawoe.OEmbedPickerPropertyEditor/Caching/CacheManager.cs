namespace Dawoe.OEmbedPickerPropertyEditor.Caching
{
    using System;
    using System.Web;
    using System.Web.Caching;

    /// <summary>
    /// The cache manager.
    /// </summary>
    public class CacheManager
    {
        /// <summary>
        /// The get or execute.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="TOutput">
        ///  The type of the object to cache
        /// </typeparam>
        /// <returns>
        /// The <see cref="TOutput"/>.
        /// </returns>
        public static TOutput GetOrExecute<TOutput>(string key, Func<TOutput> action)
        {
            object cachedObject = Get(key);

            if (cachedObject != null)
            {
                return (TOutput)cachedObject;
            }

            cachedObject = action();

            if (cachedObject != null)
            {
                Set(key, cachedObject);
            }

            return (TOutput)cachedObject;
        }

        /// <summary>
        /// Removes a entry from the cache
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public static void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Sets a item in the cache
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void Set(string key, object value)
        {
            HttpRuntime.Cache.Insert(
                key, 
                value, 
                null, 
                DateTime.Now.AddDays(1), 
                Cache.NoSlidingExpiration, 
                CacheItemPriority.Default, 
                null);
        }

        /// <summary>
        /// Gets a item from the cache
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object Get(string key)
        {
            return HttpRuntime.Cache[key];
        }       
    }
}

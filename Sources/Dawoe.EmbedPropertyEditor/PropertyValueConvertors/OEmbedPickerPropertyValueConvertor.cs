namespace Dawoe.OEmbedPickerPropertyEditor.PropertyValueConvertors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Dawoe.OEmbedPickerPropertyEditor.Caching;

    using Newtonsoft.Json;

    using Umbraco.Core;
    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// The embed property value convertor.
    /// </summary>    
    public class OEmbedPickerPropertyValueConvertor : PropertyValueConverterBase
    {
        /// <summary>
        /// Checks if this is a convertor for the propety
        /// </summary>
        /// <param name="propertyType">
        /// The property type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("Dawoe.EmbedPropertyEditor");
        }

        /// <summary>
        /// Convert the raw string into a string list
        /// </summary>
        /// <param name="propertyType">
        /// The published property type.
        /// </param>
        /// <param name="source">
        /// The value of the property
        /// </param>
        /// <param name="preview">
        /// The preview.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null || string.IsNullOrEmpty(source.ToString()))
            {
                return new List<string>();
            }

            var json = JsonConvert.DeserializeObject<List<string>>(source.ToString());

            return json;
        }

        /// <summary>
        /// Convert the source list into a MvcHtmlString or IEnumerable of MvcHtmlString depending on data type setting
        /// </summary>
        /// <param name="propertyType">
        /// The published property type.
        /// </param>
        /// <param name="source">
        /// The value of the property
        /// </param>
        /// <param name="preview">
        /// The preview.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null)
            {
                return null;
            }

            var values = (List<string>)source;

            if (this.IsMultipleDataType(propertyType.DataTypeId))
            {
                var returnValues = new List<MvcHtmlString>();

                values.ForEach(
                    x => returnValues.Add(new MvcHtmlString(x)));

                return returnValues;
            }

            var value = values.Any() ? values.First() : string.Empty;

            return new MvcHtmlString(value);
        }

        /// <summary>
        /// The get property cache level.
        /// </summary>
        /// <param name="propertyType">
        /// The property type.
        /// </param>
        /// <param name="cacheValue">
        /// The cache value.
        /// </param>
        /// <returns>
        /// The <see cref="PropertyCacheLevel"/>.
        /// </returns>
        public PropertyCacheLevel GetPropertyCacheLevel(PublishedPropertyType propertyType, PropertyCacheValue cacheValue)
        {
            PropertyCacheLevel returnLevel;
            switch (cacheValue)
            {
                case PropertyCacheValue.Object:
                    returnLevel = PropertyCacheLevel.ContentCache;
                    break;
                case PropertyCacheValue.Source:
                    returnLevel = PropertyCacheLevel.Content;
                    break;
                case PropertyCacheValue.XPath:
                    returnLevel = PropertyCacheLevel.Content;
                    break;
                default:
                    returnLevel = PropertyCacheLevel.None;
                    break;
            }

            return returnLevel;
        }

        /// <summary>
        /// The get property value type.
        /// </summary>
        /// <param name="propertyType">
        /// The property type.
        /// </param>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public Type GetPropertyValueType(PublishedPropertyType propertyType)
        {
            return this.IsMultipleDataType(propertyType.DataTypeId) ? typeof(IEnumerable<MvcHtmlString>) : typeof(MvcHtmlString);
        }

        /// <summary>
        /// The is multiple data type.
        /// </summary>
        /// <param name="dataTypeId">
        /// The data type id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsMultipleDataType(int dataTypeId)
        {

            return
                CacheManager.GetOrExecute<bool>(
                    string.Format("Dawoe.EmbedPropertyEditor.AllowMultiple_{0}", dataTypeId),
                    () =>
                        {
                            var dts = ApplicationContext.Current.Services.DataTypeService;
                            var allowMultiplePrevalue =
                                dts.GetPreValuesCollectionByDataTypeId(dataTypeId)
                                    .PreValuesAsDictionary.FirstOrDefault(
                                        x => string.Equals(x.Key, "allowmultiple", StringComparison.InvariantCultureIgnoreCase)).Value;

                            return allowMultiplePrevalue != null
                                   && allowMultiplePrevalue.Value.TryConvertTo<bool>().Result;
                        });
        }
    }
}

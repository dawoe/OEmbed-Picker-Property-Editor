namespace Dawoe.EmbedPropertyEditor.PropertyValueConvertors
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// The embed property value convertor.
    /// </summary>
    [PropertyValueType(typeof(List<MvcHtmlString>))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class EmbedPropertyValueConvertor : PropertyValueConverterBase
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

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            var returnValue = new List<MvcHtmlString>();

            if (source == null || string.IsNullOrEmpty(source.ToString()))
            {                
                return returnValue;
            }

            var json = JsonConvert.DeserializeObject(source.ToString());

            return returnValue;
        }
    }
}

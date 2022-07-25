// <copyright file="OEmbedPickerValueConverter.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dawoe.OEmbedPickerPropertyEditor.Core.Configuration;
using Dawoe.OEmbedPickerPropertyEditor.Core.Models;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Extensions;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters
{
    /// <summary>
    /// Represents a the property value converter for the OEmbed picker.
    /// </summary>
    public class OEmbedPickerValueConverter : PropertyValueConverterBase
    {
        /// <inheritdoc />
        public override bool IsConverter(IPublishedPropertyType propertyType) =>
            Constants.DataEditorAlias.Equals(propertyType.EditorAlias);

        /// <inheritdoc />
        public override Type GetPropertyValueType(IPublishedPropertyType propertyType) =>
            propertyType.DataType.ConfigurationAs<OEmbedPickerConfiguration>().AllowMultiple
                ? typeof(IEnumerable<OEmbedItem>)
                : typeof(OEmbedItem);

        /// <inheritdoc />
        public override bool? IsValue(object value, PropertyValueLevel level) => value?.ToString() != "[]";

        /// <inheritdoc />
        public override object ConvertSourceToIntermediate(
            IPublishedElement owner,
            IPublishedPropertyType propertyType,
            object source,
            bool preview) =>
            source?.ToString();

        /// <inheritdoc />
        public override object ConvertIntermediateToObject(
            IPublishedElement owner,
            IPublishedPropertyType propertyType,
            PropertyCacheLevel referenceCacheLevel,
            object inter,
            bool preview)
        {
            var isMultiple = this.IsMultipleDataType(propertyType.DataType);

            var sourceString = inter?.ToString();

            if (string.IsNullOrWhiteSpace(sourceString))
            {
                return isMultiple ? Enumerable.Empty<OEmbedItem>() : null;
            }

            if (sourceString.DetectIsJson())
            {
                try
                {
                    var items = JsonConvert.DeserializeObject<List<OEmbedItem>>(sourceString);

                    return isMultiple ? items : this.FirstOrDefault(items);
                }
                catch
                {
                }
            }

            return isMultiple ? Enumerable.Empty<OEmbedItem>() : null;
        }

        private bool IsMultipleDataType(PublishedDataType dataType)
        {
            var config = ConfigurationEditor.ConfigurationAs<OEmbedPickerConfiguration>(dataType.Configuration);
            return config.AllowMultiple;
        }

        private object FirstOrDefault(IList items) => items.Count == 0 ? null : items[0];
    }
}

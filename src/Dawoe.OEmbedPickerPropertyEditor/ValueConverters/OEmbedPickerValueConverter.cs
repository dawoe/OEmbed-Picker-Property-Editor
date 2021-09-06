// <copyright file="OEmbedPickerValueConverter.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Dawoe.OEmbedPickerPropertyEditor.Configuration;
using Dawoe.OEmbedPickerPropertyEditor.Models;
using Newtonsoft.Json;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.ValueConverters
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
            var allowMultiple = propertyType.DataType.ConfigurationAs<OEmbedPickerConfiguration>().AllowMultiple;

            if (string.IsNullOrWhiteSpace(inter?.ToString()))
            {
                return allowMultiple ? Enumerable.Empty<OEmbedItem>() : null;
            }

            var items = JsonConvert.DeserializeObject<List<OEmbedItem>>(inter.ToString());

            if (allowMultiple)
            {
                return items;
            }

            return items.FirstOrDefault();
        }
    }
}

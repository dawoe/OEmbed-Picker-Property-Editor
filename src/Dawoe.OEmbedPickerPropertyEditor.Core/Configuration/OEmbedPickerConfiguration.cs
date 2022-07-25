// <copyright file="OEmbedPickerConfiguration.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Configuration
{
    /// <summary>
    /// Represents the configuration for the OEmbed picker.
    /// </summary>
    public class OEmbedPickerConfiguration
    {
        /// <summary>
        /// Gets or sets a value indicating whether multiple items are allowed to be picked.
        /// </summary>
        [ConfigurationField("allowmultiple", "Allow picking of multiple items", "boolean")]
        public bool AllowMultiple { get; set; }
    }
}

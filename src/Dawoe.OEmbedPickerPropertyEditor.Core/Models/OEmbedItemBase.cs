// <copyright file="OEmbedItemBase.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Newtonsoft.Json;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Models
{
    /// <summary>
    /// Base class for OEmbed items.
    /// </summary>
    public abstract class OEmbedItemBase
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }
}

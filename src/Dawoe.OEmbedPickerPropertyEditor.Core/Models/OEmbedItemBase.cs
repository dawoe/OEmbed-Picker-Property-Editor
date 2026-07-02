// <copyright file="OEmbedItemBase.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System.Text.Json.Serialization;

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
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the preview.
        /// </summary>
        [JsonPropertyName("preview")]
        internal string Preview { get; set; }

        /// <inheritdoc />
        public override string ToString() => this.Preview;
    }
}

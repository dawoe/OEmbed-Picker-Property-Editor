// <copyright file="OEmbedItemApi.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System.Text.Json.Serialization;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Models
{
    internal class OEmbedItemApi : OEmbedItemBase
    {
        [JsonPropertyName("embedCode")]
        public string EmbedCode => this.Preview;
    }
}

// <copyright file="OEmbedItemApi.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Newtonsoft.Json;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Models
{
    internal class OEmbedItemApi : OEmbedItemBase
    {
        [JsonProperty(PropertyName = "embedCode")]
        public string EmbedCode => this.Preview;
    }
}

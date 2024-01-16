// <copyright file="OEmbedItem.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using Umbraco.Cms.Core.Strings;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Models
{
    /// <summary>
    /// Represents a item picked in the editor.
    /// </summary>
    public class OEmbedItem : OEmbedItemBase
    {
        /// <summary>
        /// Gets the embed code.
        /// </summary>
        [JsonIgnore]
        public IHtmlContent EmbedCode => new HtmlString(this.Preview);
    }
}

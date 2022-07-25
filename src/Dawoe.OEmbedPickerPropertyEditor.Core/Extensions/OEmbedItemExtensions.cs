// <copyright file="OEmbedItemExtensions.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System.Text.RegularExpressions;
using Dawoe.OEmbedPickerPropertyEditor.Models;

namespace Dawoe.OEmbedPickerPropertyEditor.Extensions
{
    /// <summary>
    /// Represents the extension methods for the <see cref="OEmbedItem"/>.
    /// </summary>
    public static class OEmbedItemExtensions
    {
        private static readonly Regex ExtractSrcRegex = new Regex("<iframe ?.* src=\"([^\"]+)\" ?.*>", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// Extracts the value of the src attribute of the iframe of the embed code.
        /// </summary>
        /// <param name="input">A <see cref="OEmbedItem"/>.</param>
        /// <returns>The src of the iframe or a empty string.</returns>
        public static string GetEmbedSrc(this OEmbedItem input)
        {
            var embedCode = input?.EmbedCode;

            if (input?.EmbedCode == null || string.IsNullOrWhiteSpace(input.EmbedCode.ToString()))
            {
                return string.Empty;
            }

            var srcMatch = ExtractSrcRegex.Match(embedCode.ToString());

            return srcMatch.Success ? srcMatch.Groups[1].Value : string.Empty;
        }
    }
}

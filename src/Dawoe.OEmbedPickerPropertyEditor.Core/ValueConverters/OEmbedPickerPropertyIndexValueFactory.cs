// <copyright file="OEmbedPickerPropertyIndexValueFactory.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters;

/// <summary>
/// Provides index values for the OEmbed Picker property editor.
/// </summary>
public class OEmbedPickerPropertyIndexValueFactory : IPropertyIndexValueFactory
{
    private static readonly Regex IframeTitleRegex = new Regex(
        @"title\s*=\s*[""']?([^""'\s>]+)[""']?",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <inheritdoc />
    public IEnumerable<IndexValue> GetIndexValues(
        IProperty property,
        string? culture,
        string? segment,
        bool published,
        IEnumerable<string> availableCultures,
        IDictionary<Guid, IContentType> contentTypeDictionary)
    {
        var propertyValue = property.GetValue(culture, segment, published);

        if (propertyValue == null)
        {
            return [];
        }

        // The property value is JSON - try to extract titles from all embeds
        var titles = new List<string>();

        if (propertyValue is string jsonString && !string.IsNullOrWhiteSpace(jsonString))
        {
            try
            {
                // The JSON is an array of OEmbed items
                using var doc = JsonDocument.Parse(jsonString);
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var element in doc.RootElement.EnumerateArray())
                    {
                        if (element.TryGetProperty("preview", out var previewElement))
                        {
                            var preview = previewElement.GetString();
                            if (!string.IsNullOrWhiteSpace(preview))
                            {
                                // Extract title from the iframe tag
                                var match = IframeTitleRegex.Match(preview);
                                if (match.Success)
                                {
                                    titles.Add(match.Groups[1].Value);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // If JSON parsing fails, ignore
            }
        }

        // Return a single combined field with all titles (if any found)
        return
        [
            new IndexValue
            {
                Culture = culture,
                FieldName = property.Alias,
                Values = titles.Count > 0 ? titles.ToArray() : []
            }
        ];
    }
}
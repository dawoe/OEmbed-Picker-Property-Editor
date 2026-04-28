using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters;

/// <summary>
/// Provides index values for the OEmbed Picker property editor.
/// </summary>
public class OEmbedPickerPropertyIndexValueFactory : JsonPropertyIndexValueFactoryBase<OEmbedIndexItem[]>, IOEmbedPropertyIndexValueFactory
{
    private static readonly Regex IframeTitleRegex = new Regex(
    @"title\s*=\s*[""']([^""']+)[""']",
    RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private readonly IJsonSerializer _jsonSerializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="OEmbedPickerPropertyIndexValueFactory"/> class.
    /// </summary>
    /// <param name="jsonSerializer">The JSON serializer.</param>
    /// <param name="indexingSettings">The indexing settings.</param>
    public OEmbedPickerPropertyIndexValueFactory(
        IJsonSerializer jsonSerializer,
        IOptionsMonitor<IndexingSettings> indexingSettings)
        : base(jsonSerializer, indexingSettings)
    {
        _jsonSerializer = jsonSerializer;
    }

    public override IEnumerable<IndexValue> GetIndexValues(
    IProperty property,
    string? culture,
    string? segment,
    bool published,
    IEnumerable<string> availableCultures,
    IDictionary<Guid, IContentType> contentTypeDictionary)
    {
        // Manually pull the value to ensure we aren't being filtered out
        var val = property.GetValue(culture, segment, published);

        if (val is string json && !string.IsNullOrWhiteSpace(json))
        {
            var deserialized = _jsonSerializer.Deserialize<OEmbedIndexItem[]>(json);
            if (deserialized != null)
            {
                // Call your Handle method
                return Handle(deserialized, property, culture, segment, published, availableCultures, contentTypeDictionary);
            }
        }

        return Array.Empty<IndexValue>();
    }

    /// <inheritdoc />
    protected override IEnumerable<IndexValue> Handle(
        OEmbedIndexItem[] deserializedPropertyValue,
        IProperty property,
        string? culture,
        string? segment,
        bool published,
        IEnumerable<string> availableCultures,
        IDictionary<Guid, IContentType> contentTypeDictionary)
    {
        var titles = new List<string>();

        foreach (var item in deserializedPropertyValue ?? Array.Empty<OEmbedIndexItem>())
        {
            if (!string.IsNullOrWhiteSpace(item.Preview))
            {
                var match = IframeTitleRegex.Match(item.Preview);
                if (match.Success)
                {
                    titles.Add(match.Groups[1].Value);
                }
            }
        }

        if (titles.Count == 0)
        {
            yield break; // Don't add anything to the index if no titles found
        }

        yield return new IndexValue
        {
            Culture = culture,
            FieldName = property.Alias,
            Values = titles,
        };
    }


}

/// <summary>
/// DTO for deserializing OEmbed items from the property value JSON.
/// </summary>
public class OEmbedIndexItem
{
    public string? Url { get; set; }

    public string? Preview { get; set; }
}

/// <summary>
///     Represents a property index value factory specifically for OEmbed properties.
/// </summary>
/// <remarks>
///     This marker interface allows for specialized indexing of OEmbed values,
///     enabling proper handling of multiple Oembed values per property.
/// </remarks>
public interface IOEmbedPropertyIndexValueFactory : IPropertyIndexValueFactory
{
}

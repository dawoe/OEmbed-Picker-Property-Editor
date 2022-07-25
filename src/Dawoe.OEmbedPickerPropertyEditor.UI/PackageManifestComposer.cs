// <copyright file="PackageManifestComposer.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Dawoe.OEmbedPickerPropertyEditor.UI
{
    /// <summary>
    /// Represents a <see cref="IComposer"/> to register the package manifest.
    /// </summary>
    internal class PackageManifestComposer : IComposer
    {
        /// <inheritdoc />
        public void Compose(IUmbracoBuilder builder) => builder.ManifestFilters().Append<PackageManifestFilter>();
    }
}

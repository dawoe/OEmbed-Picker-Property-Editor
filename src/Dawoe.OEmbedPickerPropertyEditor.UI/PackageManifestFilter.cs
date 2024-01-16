// <copyright file="PackageManifestFilter.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.Manifest;

namespace Dawoe.OEmbedPickerPropertyEditor.UI
{
    /// <summary>
    /// Represents a <see cref="IManifestFilter"/> to register back office assets.
    /// </summary>
    internal class PackageManifestFilter : IManifestFilter
    {
        /// <inheritdoc />
        public void Filter(List<PackageManifest> manifests) =>
            manifests.Add(new()
            {
                PackageName = "Dawoe.OEmbedPickerPropertyEditor",
                Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Scripts = new[]
                {
                    "/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/scripts/editor.controller.js",
                },
                Stylesheets = new[]
                {
                    "/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/css/editor.styles.css",
                },
            });
    }
}

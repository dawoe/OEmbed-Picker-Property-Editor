// <copyright file="OEmbedPickerConfigurationEditor.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Configuration
{
    /// <summary>
    /// Represents the configuration editor for the OEmbed picker.
    /// </summary>
    public class OEmbedPickerConfigurationEditor : ConfigurationEditor<OEmbedPickerConfiguration>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OEmbedPickerConfigurationEditor"/> class.
        /// </summary>
        /// <param name="ioHelper">A IO Helper.</param>
        public OEmbedPickerConfigurationEditor(IIOHelper ioHelper)
            : base(ioHelper)
        {
        }

        /// <summary>
        /// Gets the default configuration object.
        /// </summary>
        public override object DefaultConfigurationObject { get; } = new OEmbedPickerConfiguration { AllowMultiple = false };
    }
}

// <copyright file="OEmbedPickerConfigurationEditor.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Configuration;

public class OEmbedPickerConfigurationEditor(IIOHelper ioHelper)
    : ConfigurationEditor<OEmbedPickerConfiguration>(ioHelper);

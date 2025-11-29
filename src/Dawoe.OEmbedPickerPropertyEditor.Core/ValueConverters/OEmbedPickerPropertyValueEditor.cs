// <copyright file="OEmbedPickerPropertyValueEditor.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Strings;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters;

public class OEmbedPickerPropertyValueEditor : DataValueEditor
{
    public OEmbedPickerPropertyValueEditor(IShortStringHelper shortStringHelper, IJsonSerializer jsonSerializer)
        : base(shortStringHelper, jsonSerializer)
    {
    }

    public OEmbedPickerPropertyValueEditor(IShortStringHelper shortStringHelper, IJsonSerializer jsonSerializer, IIOHelper ioHelper, DataEditorAttribute attribute)
        : base(shortStringHelper, jsonSerializer, ioHelper, attribute)
    {
    }
}

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

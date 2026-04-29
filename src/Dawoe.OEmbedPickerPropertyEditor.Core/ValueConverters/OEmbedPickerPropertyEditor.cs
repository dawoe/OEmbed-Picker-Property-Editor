using Dawoe.OEmbedPickerPropertyEditor.Core.Configuration;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters;

[DataEditor(Constants.DataEditorAlias, ValueType = ValueTypes.Json)]
public class OEmbedPickerPropertyEditor(IDataValueEditorFactory dataValueEditorFactory, IIOHelper ioHelper, IOEmbedPropertyIndexValueFactory oEmbedPropertyIndexValueFactory)
    : DataEditor(dataValueEditorFactory)
{
    /// <inheritdoc />
    public override IPropertyIndexValueFactory PropertyIndexValueFactory => oEmbedPropertyIndexValueFactory;

    /// <inheritdoc />
    protected override IDataValueEditor CreateValueEditor() => this.DataValueEditorFactory.Create<OEmbedPickerPropertyValueEditor>(this.Attribute);

    /// <inheritdoc />
    protected override IConfigurationEditor CreateConfigurationEditor() => new OEmbedPickerConfigurationEditor(ioHelper);
}

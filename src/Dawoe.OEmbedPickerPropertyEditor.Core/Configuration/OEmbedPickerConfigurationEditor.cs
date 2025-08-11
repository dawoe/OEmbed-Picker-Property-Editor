using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Configuration;

public class OEmbedPickerConfigurationEditor(IIOHelper ioHelper)
    : ConfigurationEditor<OEmbedPickerConfiguration>(ioHelper);

namespace Dawoe.OEmbedPickerPropertyEditor
{
    using Umbraco.Core.Logging;
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// Represents the OEmbed picker data editor
    /// </summary>
    [DataEditor(Constants.DataEditorAlias, "OEmbed Picker", "~/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/views/editor.html", ValueType = "JSON", Group = "pickers", Icon = "icon-tv")]
    internal class OEmbedPickerDataEditor : DataEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OEmbedPickerDataEditor"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="type">
        /// The editor type type.
        /// </param>
        public OEmbedPickerDataEditor(ILogger logger, EditorType type = EditorType.PropertyValue)
            : base(logger, type)
        {
        }

        /// <inheritdoc />
        protected override IConfigurationEditor CreateConfigurationEditor() => new OEmbedPickerConfigurationEditor();
    }
}

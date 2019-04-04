namespace Dawoe.OEmbedPickerPropertyEditor.Configuration
{
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// Represents the configuration editor for the OEmbed picker
    /// </summary>
    internal class OEmbedPickerConfigurationEditor : ConfigurationEditor<OEmbedPickerConfiguration>
    {
        /// <summary>
        /// Gets the default configuration object.
        /// </summary>
        public override object DefaultConfigurationObject { get; } = new OEmbedPickerConfiguration { AllowMultiple = false };
    }
}

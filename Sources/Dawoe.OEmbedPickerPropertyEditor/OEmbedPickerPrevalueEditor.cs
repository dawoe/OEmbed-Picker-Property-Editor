namespace Dawoe.OEmbedPickerPropertyEditor
{
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// The embed prevalue editor.
    /// </summary>
    internal class OEmbedPickerPrevalueEditor : PreValueEditor
    {
        /// <summary>
        /// Gets or sets a value indicating whether allow multiple.
        /// </summary>
        [PreValueField(Constants.AllowMultiplePrevalue, "Allow multiple", "boolean",
            Description = "Allow the editor pick multiple embeds")]
        public bool AllowMultiple { get; set; }
    }
}

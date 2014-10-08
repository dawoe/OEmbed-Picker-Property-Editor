namespace Dawoe.EmbedPropertyEditor
{
    using Umbraco.Core.PropertyEditors;

    /// <summary>
    /// The embed prevalue editor.
    /// </summary>
    internal class EmbedPrevalueEditor : PreValueEditor
    {
        /// <summary>
        /// Gets or sets a value indicating whether allow multiple.
        /// </summary>
        [PreValueField("allowmultiple", "Allow multiple", "checkbox",
            Description = "Allow the editor pick multiple embeds")]
        public bool AllowMultiple { get; set; }
    }
}

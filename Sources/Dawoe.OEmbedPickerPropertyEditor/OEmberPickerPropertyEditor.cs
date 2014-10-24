namespace Dawoe.OEmbedPickerPropertyEditor
{
    using ClientDependency.Core;

    using Umbraco.Core.PropertyEditors;
    using Umbraco.Web.PropertyEditors;

    /// <summary>
    /// The embed property editor.
    /// </summary>
    [PropertyEditor(Constants.PropertyEditorAlias, "OEmbed Picker",
        "/" + Constants.ResourceFolder + "/Resource/editor.html", HideLabel = false, IsParameterEditor = false)]
    [PropertyEditorAsset(ClientDependencyType.Javascript,
       "/" + Constants.ResourceFolder + "/Resource/editor.controller.js")]
    [PropertyEditorAsset(ClientDependencyType.Css, "/" + Constants.ResourceFolder + "/Resource/styles.css")]
    public class OEmberPickerPropertyEditor : PropertyEditor
    {
        /// <summary>
        /// Set the prevalue editor
        /// </summary>
        /// <returns>
        /// The <see cref="PreValueEditor"/>.
        /// </returns>
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new OEmbedPickerPrevalueEditor();
        }
    }
}

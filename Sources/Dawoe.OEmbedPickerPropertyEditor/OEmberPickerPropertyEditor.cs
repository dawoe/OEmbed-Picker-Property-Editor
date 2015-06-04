namespace Dawoe.OEmbedPickerPropertyEditor
{
    using ClientDependency.Core;

    using Umbraco.Core.PropertyEditors;
    using Umbraco.Web.PropertyEditors;

    /// <summary>
    /// The embed property editor.
    /// </summary>
    [PropertyEditor(Constants.PropertyEditorAlias, "OEmbed Picker",
        Constants.ViewPath, HideLabel = false, IsParameterEditor = false)]
    [PropertyEditorAsset(ClientDependencyType.Javascript,
       Constants.ControllerPath)]
    [PropertyEditorAsset(ClientDependencyType.Css, Constants.CssPath)]
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

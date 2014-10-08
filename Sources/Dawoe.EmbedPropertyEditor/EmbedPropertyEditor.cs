namespace Dawoe.EmbedPropertyEditor
{
    using ClientDependency.Core;

    using Umbraco.Core.PropertyEditors;
    using Umbraco.Web.PropertyEditors;

    /// <summary>
    /// The embed property editor.
    /// </summary>
    [PropertyEditor("Dawoe.EmbedPropertyEditor", "Embed Picker",
        "/App_Plugins/DawoeEmbedPropertyEditor/Resource/editor.html", HideLabel = false, IsParameterEditor = false)]
    [PropertyEditorAsset(ClientDependencyType.Javascript, "/App_Plugins/DawoeEmbedPropertyEditor/Resource/editor.controller.js")]
    public class EmbedPropertyEditor : PropertyEditor
    {
        /// <summary>
        /// Set the prevalue editor
        /// </summary>
        /// <returns>
        /// The <see cref="PreValueEditor"/>.
        /// </returns>
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new EmbedPrevalueEditor();
        }
    }
}

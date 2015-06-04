namespace Dawoe.OEmbedPickerPropertyEditor
{
    /// <summary>
    /// The constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The property editor alias.
        /// </summary>
        public const string PropertyEditorAlias = "Dawoe.OEmbedPickerPropertyEditor";

        /// <summary>
        /// The data type cache key.
        /// </summary>
        public const string DataTypeCacheKey = "Dawoe.OEmbedPickerPropertyEditor.AllowMultiple_{0}";

        /// <summary>
        /// The allow multiple prevalue.
        /// </summary>
        public const string AllowMultiplePrevalue = "allowmultiple";

        /// <summary>
        /// The resource folder.
        /// </summary>
        public const string ResourceFolder = "App_Plugins/DawoeOEmbedPickerPropertyEditor";

        /// <summary>
        /// The plugin root path.
        /// </summary>
        internal const string PluginPath = "/App_Plugins/Dawoe.OEmbedPickerPropertyEditor";       

        /// <summary>
        /// The version path.
        /// </summary>
        internal const string VersionPath = PluginPath + Version;

        /// <summary>
        /// The controller path.
        /// </summary>
        internal const string ControllerPath = VersionPath + "/controller.js";

        /// <summary>
        /// The view path.
        /// </summary>
        internal const string ViewPath = VersionPath + "/view.html";

        /// <summary>
        /// The css path.
        /// </summary>
        internal const string CssPath = VersionPath + "/styles.css";

        /// <summary>
        /// The namespace for client scripts the embedded resources can be found in
        /// </summary>
        internal const string ClientScriptsNameSpace = "Dawoe.OEmbedPickerPropertyEditor.Scripts";

        /// <summary>
        /// The namespace for client styles the embedded resources can be found in
        /// </summary>
        internal const string ClientStylesNameSpace = "Dawoe.OEmbedPickerPropertyEditor.Css";

        /// <summary>
        /// The namespace for client views the embedded resources can be found in
        /// </summary>
        internal const string ClientViewsNameSpace = "Dawoe.OEmbedPickerPropertyEditor.Views";

        /// <summary>
        /// The version folder path
        /// </summary>
        private const string Version = "/1_0_1";
    }
}

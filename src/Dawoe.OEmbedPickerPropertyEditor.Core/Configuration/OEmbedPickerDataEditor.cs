// <copyright file="OEmbedPickerDataEditor.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Configuration
{
    /// <summary>
    /// Represents the OEmbed picker data editor.
    /// </summary>
    [DataEditor(Constants.DataEditorAlias, "OEmbed Picker", "~/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/views/editor.html", ValueType = "JSON", Group = "pickers", Icon = "icon-tv")]
    public class OEmbedPickerDataEditor : DataEditor
    {
        private readonly IIOHelper ioHelper;
        private readonly IEditorConfigurationParser editorConfigurationParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="OEmbedPickerDataEditor"/> class.
        /// </summary>
        /// <param name="dataValueEditorFactory">A <see cref="IDataValueEditorFactory"/>.</param>
        /// <param name="ioHelper">A <see cref="IIOHelper"/>.</param>
        /// <param name="editorConfigurationParser">A <see cref="IEditorConfigurationParser"/>.</param>
        public OEmbedPickerDataEditor(IDataValueEditorFactory dataValueEditorFactory, IIOHelper ioHelper, IEditorConfigurationParser editorConfigurationParser)
            : base(dataValueEditorFactory)
        {
            this.ioHelper = ioHelper;
            this.editorConfigurationParser = editorConfigurationParser;
        }

        /// <inheritdoc />
        protected override IConfigurationEditor CreateConfigurationEditor() => new OEmbedPickerConfigurationEditor(this.ioHelper, this.editorConfigurationParser);
    }
}

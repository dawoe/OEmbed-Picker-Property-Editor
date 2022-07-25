// <copyright file="OEmbedPickerDataEditor.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Configuration
{
    /// <summary>
    /// Represents the OEmbed picker data editor.
    /// </summary>
    [DataEditor(Constants.DataEditorAlias, "OEmbed Picker", "~/App_Plugins/Dawoe.OEmbedPickerPropertyEditor/views/editor.html", ValueType = "JSON", Group = "pickers", Icon = "icon-tv")]
    public class OEmbedPickerDataEditor : DataEditor
    {
        private readonly IIOHelper ioHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OEmbedPickerDataEditor"/> class.
        /// </summary>
        /// <param name="dataValueEditorFactory">A data value editor factory</param>
        /// <param name="ioHelper">A IO helper.</param>
        public OEmbedPickerDataEditor(IDataValueEditorFactory dataValueEditorFactory, IIOHelper ioHelper)
            : base(dataValueEditorFactory) => this.ioHelper = ioHelper;

        /// <inheritdoc />
        protected override IConfigurationEditor CreateConfigurationEditor() => new OEmbedPickerConfigurationEditor(this.ioHelper);
    }
}

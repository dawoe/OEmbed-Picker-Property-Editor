// <copyright file="UpdatePropertyEditorUiAlias.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System.Threading.Tasks;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Persistence.Dtos;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Migrations.V_16_0_1
{
    internal sealed class UpdatePropertyEditorUiAlias : AsyncMigrationBase
    {
        public UpdatePropertyEditorUiAlias(IMigrationContext context)
            : base(context)
        {
        }

        protected override async Task MigrateAsync()
        {
            var dataTypes = await this.Database.Query<DataTypeDto>()
                .Where(x => x.EditorUiAlias == "Dawoe.OEmbedPickerPropertyEditor").ToListAsync();

            foreach (var dataType in dataTypes)
            {
                dataType.EditorUiAlias = "Dawoe.OEmbedPickerPropertyEditor.Ui";

                await this.Database.UpdateAsync(dataType);
            }
        }
    }
}

using Dawoe.OEmbedPickerPropertyEditor.Core.Migrations.V_16_0_1;
using Umbraco.Cms.Infrastructure.Migrations;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Migrations
{
    internal class OEmbedMigrationPlan : MigrationPlan
    {
        public OEmbedMigrationPlan()
            : base("Dawoe.OEmbedPickerPropertyEditor")
        {
            this.RunMigrations();
        }

        /// <inheritdoc />
        public override string InitialState => string.Empty;

        private void RunMigrations()
        {
            this.From(this.InitialState)
                .To<UpdatePropertyEditorUiAlias>("16.0.1");
        }
    }
}

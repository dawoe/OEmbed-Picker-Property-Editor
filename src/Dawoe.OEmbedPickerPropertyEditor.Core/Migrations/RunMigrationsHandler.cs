using System.Threading;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace Dawoe.OEmbedPickerPropertyEditor.Core.Migrations;

internal sealed class RunMigrationsHandler(
    IMigrationPlanExecutor migrationPlanExecutor,
    ICoreScopeProvider coreScopeProvider,
    IKeyValueService keyValueService,
    IRuntimeState runtimeState)
    : INotificationAsyncHandler<UmbracoApplicationStartingNotification>
{
    public async Task HandleAsync(UmbracoApplicationStartingNotification notification, CancellationToken cancellationToken)
    {
        if (runtimeState.Level < RuntimeLevel.Run)
        {
            return;
        }

        var upgrader = new Upgrader(new OEmbedMigrationPlan());

        await upgrader.ExecuteAsync(migrationPlanExecutor, coreScopeProvider, keyValueService);
    }
}

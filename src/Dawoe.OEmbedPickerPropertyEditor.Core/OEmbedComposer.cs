using Dawoe.OEmbedPickerPropertyEditor.Core.Migrations;
using Dawoe.OEmbedPickerPropertyEditor.Core.ValueConverters;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Dawoe.OEmbedPickerPropertyEditor.Core
{
    internal sealed class OEmbedComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, RunMigrationsHandler>();
            builder.Services.AddSingleton<IOEmbedPropertyIndexValueFactory, OEmbedPickerPropertyIndexValueFactory>();
        }
    }
}

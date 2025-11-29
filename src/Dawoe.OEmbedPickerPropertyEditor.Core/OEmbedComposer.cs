// <copyright file="OEmbedComposer.cs" company="Umbraco community">
// Copyright (c) Dave Woestenborghs and contributors. Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using Dawoe.OEmbedPickerPropertyEditor.Core.Migrations;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Dawoe.OEmbedPickerPropertyEditor.Core
{
    internal sealed class OEmbedComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
            => builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, RunMigrationsHandler>();
    }
}

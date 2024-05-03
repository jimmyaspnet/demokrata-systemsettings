// <copyright file="SystemSettingSubscriber.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Common.Subscribers;

using System.Threading;
using System.Threading.Tasks;
using Demokrata.Core.Notifications;
using Demokrata.SystemSettings.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

/// <summary>
/// The subscriber for the update system setting event
/// </summary>
/// <seealso cref="T" />
public class SystemSettingSubscriber(ILogger<SystemSettingSubscriber> logger) : INotificationHandler<NotificationUpdate<SystemSetting>>
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<SystemSettingSubscriber> logger = logger;

    public Task Handle(NotificationUpdate<SystemSetting> notification, CancellationToken cancellationToken)
    {
        //Clear cache
        this.logger.LogInformation("Mensaje");
        return Task.CompletedTask;
    }
}
// <copyright file="UpdateSystemVariableHandler.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;

using System.Threading;
using System.Threading.Tasks;
using Demokrata.Core.Exceptions;
using Demokrata.Core.Notifications;
using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The handler to update a system setting
/// </summary>
/// <seealso cref="T" />
public class UpdateSystemVariableHandler(IDataContext dataContext, IMediator mediator) : IRequestHandler<UpdateSystemVariable, UpdateSystemVariable>
{
    /// <summary>
    /// The data context
    /// </summary>
    private readonly IDataContext dataContext = dataContext;

    /// <summary>
    /// The mediator
    /// </summary>
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="Demokrata.Core.Exceptions.HttpException"></exception>
    public async Task<UpdateSystemVariable> Handle(UpdateSystemVariable request, CancellationToken cancellationToken)
    {
        var systemSetting = await this.dataContext.SystemSettings
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(t => t.SystemSettingID == request.SystemSettingID, cancellationToken);

        if (systemSetting is null)
        {
            throw new HttpException(System.Net.HttpStatusCode.NotFound);
        }

        systemSetting.Value = request.Value;
        systemSetting.KeyWord = request.KeyWord;
        await this.dataContext.SaveChangesAsync(cancellationToken);

        var notification = new NotificationUpdate<SystemSetting>(systemSetting);
        await this.mediator.Publish(notification, cancellationToken);

        return request;
    }
}
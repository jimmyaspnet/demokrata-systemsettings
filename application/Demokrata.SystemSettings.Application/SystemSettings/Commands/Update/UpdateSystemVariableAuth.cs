// <copyright file="UpdateSystemVariableAuth.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;

using System.Threading;
using System.Threading.Tasks;
using Demokrata.Core.Exceptions;
using Demokrata.Core.Interfaces;
using Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;
using MediatR;

/// <summary>
/// This class validate the permissions
/// </summary>
/// <seealso cref="Demokrata.Core.Interfaces.IAuthorizer&lt;Demokrata.SystemSettings.Application.SystemSettings.Commands.Update.UpdateSystemVariable&gt;" />
public class UpdateSystemVariableAuth(IMediator mediator) : IAuthorizer<UpdateSystemVariable>
{
    /// <summary>
    /// The mediator
    /// </summary>
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Builds the policy.
    /// </summary>
    /// <param name="instance">The instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    /// <exception cref="Exception">$"The key SettingsAllowedToChangeByAdmin not found</exception>
    /// <exception cref="HttpException">System.Net.HttpStatusCode.Forbidden</exception>
    public async Task BuildPolicy(UpdateSystemVariable instance, CancellationToken cancellationToken)
    {
        var setting = await this.mediator.Send(new GetByKeyWord("SettingsAllowedToChangeByAdmin"), cancellationToken);

        if (setting is null)
        {
            throw new Exception($"The key SettingsAllowedToChangeByAdmin not found");
        }

        var allowedKeysToChange = setting.Value.ToLower().Split([',']);
        if (instance.KeyWord is not null && !allowedKeysToChange.Contains(instance.KeyWord.ToLower()))
        {
            throw new HttpException(System.Net.HttpStatusCode.Forbidden);
        }

        //check roles and permissions
    }
}
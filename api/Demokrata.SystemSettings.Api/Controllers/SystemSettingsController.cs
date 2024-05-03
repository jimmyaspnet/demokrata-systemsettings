// <copyright file="SystemSettingsController.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using MediatR;
using Demokrata.SystemSettings.Application.SystemSettings.Queries.Get;
using Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;
using Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;

/// <summary>
/// The controller to get a list of system variables
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("[controller]")]
public class SystemSettingsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// The mediator
    /// </summary>
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// Gets a list of system variables.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetSystemSetting model, CancellationToken token)
    {
        var result = await this.mediator.Send(model, token);
        return this.Ok(result);
    }

    /// <summary>
    /// Gets a system setting entity by its keyword.
    /// </summary>
    /// <param name="keyWord">The key word.</param>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    [HttpGet("{keyWord}")]
    public async Task<IActionResult> Get(string keyWord, CancellationToken token)
    {
        var result = await this.mediator.Send(new GetByKeyWord(keyWord), token);
        return this.Ok(result);
    }

    /// <summary>
    /// Updates a system setting according to the KeyWord.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="token">The token.</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateSystemVariable model, CancellationToken token)
    {
        model.SystemSettingID = id;
        var result = await this.mediator.Send(model, token);
        return this.Ok(result);
    }
}
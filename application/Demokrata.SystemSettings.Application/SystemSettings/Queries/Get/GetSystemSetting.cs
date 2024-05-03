// <copyright file="GetSystemSetting.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Queries.Get;

using Demokrata.Core.Models;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using MediatR;

/// <summary>
/// The model to get a list of SystemSettings
/// </summary>
/// <seealso cref="T" />
public class GetSystemSetting : BaseFilter, IRequest<PagedList<SystemSettingDto>>
{
    /// <summary>
    /// Gets or sets the key words.
    /// </summary>
    /// <value>
    /// The key words.
    /// </value>
    public string[]? KeyWords { get; set; }

    /// <summary>
    /// Gets or sets the keyword.
    /// </summary>
    /// <value>
    /// The keyword.
    /// </value>
    public string? KeyWord { get; set; }
}
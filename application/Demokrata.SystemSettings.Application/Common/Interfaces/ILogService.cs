// <copyright file="ILogService.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Common.Interfaces;
using System.Threading.Tasks;

/// <summary>
/// The interface for the log service
/// </summary>
public interface ILogService
{
    /// <summary>
    /// Executes this instance.
    /// </summary>
    /// <returns></returns>
    Task Exec(CancellationToken cancellationToken);
}
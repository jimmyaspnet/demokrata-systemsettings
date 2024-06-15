// <copyright file="LogService.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Infraestructure.Services;

using System.Threading.Tasks;
using Demokrata.SystemSettings.Application.Common.Interfaces;

/// <summary>
/// Initializes a new instance of the <see cref="LogService"/> class.
/// </summary>
/// <param name="httpClient">The HTTP client.</param>
public class LogService(HttpClient httpClient) : ILogService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient httpClient = httpClient;

    /// <summary>
    /// Executes this instance.
    /// </summary>
    /// <returns></returns>
    public async Task Exec(CancellationToken cancellationToken)
    {
        await this.httpClient.GetAsync("api", cancellationToken);
    }
}
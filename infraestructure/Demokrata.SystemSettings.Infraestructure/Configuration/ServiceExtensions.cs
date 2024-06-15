// <copyright file="ServiceExtensions.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Infraestructure.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Infraestructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The service extensions
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<ILogService, LogService>(config =>
        {
            config.BaseAddress = new Uri(configuration["AppSettings:ApiUrlUsers"]);
        });

        return services;
    }
}
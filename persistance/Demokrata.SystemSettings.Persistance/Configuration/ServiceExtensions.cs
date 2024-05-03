// <copyright file="ServiceExtensions.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Persistance.Configuration;

using Demokrata.SystemSettings.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(11, 1, 0));

        services.AddDbContext<IDataContext, DataContext>(options => 
        options
        .UseMySql(configuration.GetConnectionString("Default"), serverVersion)
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s)));

        return services;
    }
}
// <copyright file="IntegrationFactory.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.IntegrationTest.Configuration;

using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Persistance.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The integration factory
/// </summary>
/// <typeparam name="TStartup">The type of the startup.</typeparam>
/// <seealso cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory&lt;TStartup&gt;" />
public class IntegrationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    /// <summary>
    /// Gets the client.
    /// </summary>
    /// <returns></returns>
    public HttpClient GetClient()
    {
        var client = this.CreateClient();

        client.DefaultRequestHeaders.Add("SiteKey", 1.ToString());

        return client;
    }

    /// <summary>
    /// Gives a fixture an opportunity to configure the application before it gets built.
    /// </summary>
    /// <param name="builder">The <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" /> for the application.</param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddDbContext<IDataContext, DataContext>(options =>
            {
                options.UseInMemoryDatabase("default");
                options.UseInternalServiceProvider(serviceProvider);
            });

            var scopeServiceProvider = services.BuildServiceProvider();
            using var scope = scopeServiceProvider.CreateScope();

            var scopedServices = scope.ServiceProvider;
            using var context = scopedServices.GetRequiredService<DataContext>();
            context.Database.EnsureCreated();

            SeedHelper.Seed(context);
        })
        .UseEnvironment("Test");
    }
}
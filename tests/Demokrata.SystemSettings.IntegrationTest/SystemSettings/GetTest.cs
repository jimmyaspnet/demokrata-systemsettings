// <copyright file="GetTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.IntegrationTest.SystemSettings;

using System.Net;
using System.Threading.Tasks;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using Demokrata.SystemSettings.IntegrationTest.Configuration;

/// <summary>
/// The integration test for the end point Get
/// </summary>
/// <seealso cref="Xunit.IClassFixture&lt;Demokrata.SystemSettings.IntegrationTest.Configuration.IntegrationFactory&lt;Program&gt;&gt;" />
/// <remarks>
/// Initializes a new instance of the <see cref="GetTest"/> class.
/// </remarks>
/// <param name="factory">The factory.</param>
public class GetTest(IntegrationFactory<Program> factory) : IClassFixture<IntegrationFactory<Program>>
{
    /// <summary>
    /// The factory
    /// </summary>
    private readonly IntegrationFactory<Program> factory = factory;

    /// <summary>
    /// Givens the error not found.
    /// </summary>
    [Fact]
    public async Task GivenErrorNotFound()
    {
        var client = this.factory.GetClient();

        var response = await client.GetAsync("/systemsettings/NotFound");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    /// <summary>
    /// Givens the succesul get.
    /// </summary>
    [Fact]
    public async Task GivenSuccesulGet()
    {
        var client = this.factory.GetClient();

        var response = await client.GetAsync("/systemsettings/Title");

        var result = await IntegrationTestHelper.GetResponseContent<SystemSettingDto>(response);

        Assert.NotNull(result);
        Assert.Equal(1, result.SettingID);
    }
}
// <copyright file="GetListTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.IntegrationTest.SystemSettings;

using System.Threading.Tasks;
using Demokrata.Core.Models;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using Demokrata.SystemSettings.IntegrationTest.Configuration;

/// <summary>
/// The integration test for the end point Get (list of system settings) 
/// </summary>
/// <seealso cref="Xunit.IClassFixture&lt;Demokrata.SystemSettings.IntegrationTest.Configuration.IntegrationFactory&lt;Program&gt;&gt;" />
public class GetListTest(IntegrationFactory<Program> factory) : IClassFixture<IntegrationFactory<Program>>
{
    /// <summary>
    /// The factory
    /// </summary>
    private readonly IntegrationFactory<Program> factory = factory;

    /// <summary>
    /// Givens the succes empty.
    /// </summary>
    [Fact]
    public async Task GivenSuccesEmpty()
    {
        var client = this.factory.GetClient();

        var response = await client.GetAsync("/systemsettings?KeyWord=Nothing");

        var result = await IntegrationTestHelper.GetResponseContent<PagedList<SystemSettingDto>>(response);

        Assert.Empty(result.Results);
    }

    /// <summary>
    /// Givens the succesful list.
    /// </summary>
    [Fact]
    public async Task GivenSuccesfulList()
    {
        var client = this.factory.GetClient();

        var response = await client.GetAsync("/systemsettings");

        var result = await IntegrationTestHelper.GetResponseContent<PagedList<SystemSettingDto>>(response);

        Assert.NotNull(result);
        Assert.NotEmpty(result.Results);
    }

    /// <summary>
    /// Givens the succes one page.
    /// </summary>
    [Fact]
    public async Task GivenSuccesOnePage()
    {
        var client = this.factory.GetClient();

        var response = await client.GetAsync("/systemsettings?page=0&pageSize=1");

        var result = await IntegrationTestHelper.GetResponseContent<PagedList<SystemSettingDto>>(response);

        Assert.Single(result.Results);
        Assert.True(result.Meta.HasNextPage);
    }
}
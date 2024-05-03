// <copyright file="UpdateTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.IntegrationTest.SystemSettings;

using System.Net;
using System.Threading.Tasks;
using Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;
using Demokrata.SystemSettings.IntegrationTest.Configuration;

/// <summary>
/// The integration test for the end point put
/// </summary>
/// <seealso cref="Xunit.IClassFixture&lt;Demokrata.SystemSettings.IntegrationTest.Configuration.IntegrationFactory&lt;Program&gt;&gt;" />
public class UpdateTest(IntegrationFactory<Program> factory) : IClassFixture<IntegrationFactory<Program>>
{
    /// <summary>
    /// The factory
    /// </summary>
    private readonly IntegrationFactory<Program> factory = factory;

    /// <summary>
    /// Givens the key word required error.
    /// </summary>
    [Fact]
    public async Task GivenKeyWordRequiredError()
    {
        var client = this.factory.GetClient();

        var request = new UpdateSystemVariable
        {
            KeyWord = "",
            Value = "Value"
        };

        var model = IntegrationTestHelper.GetRequestContent(request);

        var response = await client.PutAsync("/systemsettings/1", model);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    /// <summary>
    /// Givens the not found error.
    /// </summary>
    [Fact]
    public async Task GivenNotFoundError()
    {
        var client = this.factory.GetClient();

        var request = new UpdateSystemVariable
        {
            KeyWord = "Title",
            Value = "Value"
        };

        var model = IntegrationTestHelper.GetRequestContent(request);

        var response = await client.PutAsync("/systemsettings/3", model);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    /// <summary>
    /// Givens the succesful.
    /// </summary>
    [Fact]
    public async Task GivenSuccesful()
    {
        var client = this.factory.GetClient();

        var request = new UpdateSystemVariable
        {
            KeyWord = "Title",
            Value = "Update value"
        };

        var model = IntegrationTestHelper.GetRequestContent(request);

        var response = await client.PutAsync("/systemsettings/1", model);

        var result = await IntegrationTestHelper.GetResponseContent<UpdateSystemVariable>(response);

        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(result);
    }

    /// <summary>
    /// Givens the value required error.
    /// </summary>
    [Fact]
    public async Task GivenValueRequiredError()
    {
        var client = this.factory.GetClient();

        var request = new UpdateSystemVariable
        {
            KeyWord = "Title",
            Value = string.Empty
        };

        var model = IntegrationTestHelper.GetRequestContent(request);

        var response = await client.PutAsync("/systemsettings/1", model);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
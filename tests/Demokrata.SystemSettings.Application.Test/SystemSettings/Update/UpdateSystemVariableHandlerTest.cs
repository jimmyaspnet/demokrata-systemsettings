// <copyright file="UpdateSystemVariableHandlerTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.Update;

using System.Net;
using System.Threading.Tasks;
using Demokrata.Core.Exceptions;
using Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;
using Demokrata.SystemSettings.Application.Test.Configuration;

/// <summary>
/// The unit test for the handler
/// </summary>
/// <seealso cref="TestFactory" />
public class UpdateSystemVariableHandlerTest : TestFactory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSystemVariableHandlerTest"/> class.
    /// </summary>
    public UpdateSystemVariableHandlerTest() => SeedHelper.Seed(this.Context);

    /// <summary>
    /// Givens the not found error.
    /// </summary>
    [Fact]
    public async Task GivenNotFoundError()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 3,
            KeyWord = "Title",
            Value = "Update value"
        };

        var handler = new UpdateSystemVariableHandler(this.Context, this.Mediator);

        var result = await Assert.ThrowsAsync<HttpException>(async () => await handler.Handle(model, CancellationToken.None));

        Assert.Equal(HttpStatusCode.NotFound, result.HttpStatus);
    }

    /// <summary>
    /// Givens the succesful update.
    /// </summary>
    [Fact]
    public async Task GivenSuccesfulUpdate()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            KeyWord = "Title",
            Value = "Update value"
        };

        var handler = new UpdateSystemVariableHandler(this.Context, this.Mediator);
        var result = await handler.Handle(model, CancellationToken.None);

        Assert.NotNull(result);
    }
}
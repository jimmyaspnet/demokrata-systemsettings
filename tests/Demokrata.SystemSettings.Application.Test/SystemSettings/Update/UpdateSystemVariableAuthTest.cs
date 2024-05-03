// <copyright file="UpdateSystemVariableAuthTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.Update;

using System;
using System.Net;
using System.Threading.Tasks;
using Demokrata.Core.Exceptions;
using Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;
using Demokrata.SystemSettings.Application.Test.Configuration;
using MediatR;
using Moq;

/// <summary>
/// The unit test for authorization the update
/// </summary>
/// <seealso cref="Demokrata.SystemSettings.Application.Test.Configuration.TestFactory" />
public class UpdateSystemVariableAuthTest : TestFactory
{
    /// <summary>
    /// Givens the exception not found key.
    /// </summary>
    [Fact]
    public async Task GivenExceptionNotFoundKey()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            KeyWord = "Title",
            Value = "Update value"
        };

        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(s => s.Send(It.IsAny<GetByKeyWord>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<SystemSettingDto>(null));

        var handler = new UpdateSystemVariableAuth(mockMediator.Object);

        var result = await Assert.ThrowsAsync<Exception>(async () => await handler.BuildPolicy(model, CancellationToken.None));
    }

    /// <summary>
    /// Givens the forbidden exception.
    /// </summary>
    [Fact]
    public async Task GivenForbiddenException()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            KeyWord = "Title",
            Value = "Update value"
        };

        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(s => s.Send(It.IsAny<GetByKeyWord>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new SystemSettingDto { KeyWord = model.KeyWord, Value = string.Empty }));

        var handler = new UpdateSystemVariableAuth(mockMediator.Object);

        var result = await Assert.ThrowsAsync<HttpException>(async () => await handler.BuildPolicy(model, CancellationToken.None));

        Assert.Equal(HttpStatusCode.Forbidden, result.HttpStatus);
    }

    [Fact]
    public async Task GivenSuccesfulAuthorization()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            KeyWord = "Title",
            Value = "Update value"
        };

        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(s => s.Send(It.IsAny<GetByKeyWord>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new SystemSettingDto { KeyWord = model.KeyWord, Value = "Title" }));

        var handler = new UpdateSystemVariableAuth(mockMediator.Object);

        await handler.BuildPolicy(model, CancellationToken.None);
    }
}
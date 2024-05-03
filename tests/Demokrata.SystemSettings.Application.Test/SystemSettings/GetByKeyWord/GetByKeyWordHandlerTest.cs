// <copyright file="GetByKeyWordHandlerTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.GetByKeyWord;

using System.Net;
using System.Threading.Tasks;
using Demokrata.Core.Exceptions;
using Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;
using Demokrata.SystemSettings.Application.Test.Configuration;

/// <summary>
/// The unit test for the handlers
/// </summary>
/// <seealso cref="Demokrata.SystemSettings.Application.Test.Configuration.TestFactory" />
public class GetByKeyWordHandlerTest : TestFactory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetByKeyWordHandlerTest"/> class.
    /// </summary>
    public GetByKeyWordHandlerTest() => SeedHelper.Seed(this.Context);

    /// <summary>
    /// Givens the not found error.
    /// </summary>
    [Fact]
    public async Task GivenNotFoundError()
    {
        var model = new GetByKeyWord("TitleNotFound");

        var handler = new GetByKeyWordHandler(this.Context, this.Mapper);

        var result = await Assert.ThrowsAsync<HttpException>(async () => await handler.Handle(model, CancellationToken.None));

        Assert.Equal(HttpStatusCode.NotFound, result.HttpStatus);
    }

    /// <summary>
    /// Givens the succesful.
    /// </summary>
    [Fact]
    public async Task GivenSuccesful()
    {
        var model = new GetByKeyWord("Title");

        var handler = new GetByKeyWordHandler(this.Context, this.Mapper);

        var result = await handler.Handle(model, CancellationToken.None);

        Assert.Equal(model.KeyWord, result.KeyWord);
    }
}
// <copyright file=".cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.Get;

using Demokrata.SystemSettings.Application.SystemSettings.Queries.Get;
using Demokrata.SystemSettings.Application.Test.Configuration;

/// <summary>
/// The unit test for the handler
/// </summary>
/// <seealso cref="Demokrata.SystemSettings.Application.Test.Configuration.TestFactory" />
public class GetSystemSettingHandlerTest : TestFactory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSystemSettingHandlerTest"/> class.
    /// </summary>
    public GetSystemSettingHandlerTest() => SeedHelper.Seed(this.Context);

    /// <summary>
    /// Givens the succesful all.
    /// </summary>
    [Fact]
    public async Task GivenSuccesfulAll()
    {
        var model = new GetSystemSetting();

        var handler = new GetSystemSettingHandler(this.Context, this.Mapper);

        var result = await handler.Handle(model, CancellationToken.None);

        Assert.NotEmpty(result.Results);
    }

    /// <summary>
    /// Givens the succes empty.
    /// </summary>
    [Fact]
    public async Task GivenSuccesEmpty()
    {
        var model = new GetSystemSetting { KeyWord = "Nothing" };

        var handler = new GetSystemSettingHandler(this.Context, this.Mapper);

        var result = await handler.Handle(model, CancellationToken.None);

        Assert.Empty(result.Results);
    }

    /// <summary>
    /// Givens the succes one page.
    /// </summary>
    [Fact]
    public async Task GivenSuccesOnePage()
    {
        var model = new GetSystemSetting { Page = 0, PageSize = 1 };

        var handler = new GetSystemSettingHandler(this.Context, this.Mapper);

        var result = await handler.Handle(model, CancellationToken.None);

        Assert.Single(result.Results);
        Assert.True(result.Meta.HasNextPage);
    }
}
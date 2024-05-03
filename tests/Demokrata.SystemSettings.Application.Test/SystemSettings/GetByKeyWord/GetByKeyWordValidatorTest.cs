// <copyright file="GetByKeyWordValidatorTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.GetByKeyWord;

using Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;
using Demokrata.SystemSettings.Application.Test.Configuration;
using FluentValidation.TestHelper;

/// <summary>
/// The unit test for the validators
/// </summary>
/// <seealso cref="Demokrata.SystemSettings.Application.Test.Configuration.TestFactory" />
public class GetByKeyWordValidatorTest : TestFactory
{
    /// <summary>
    /// The validator
    /// </summary>
    private readonly GetByKeyWordValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetByKeyWordValidatorTest"/> class.
    /// </summary>
    public GetByKeyWordValidatorTest()
    {
        this.validator = new GetByKeyWordValidator();
    }

    /// <summary>
    /// Givens the failed key word required.
    /// </summary>
    [Fact]
    public void GivenFailedKeyWordRequired()
    {
        var model = new GetByKeyWord("");

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.KeyWord);
    }

    /// <summary>
    /// Givens the succesful.
    /// </summary>
    [Fact]
    public void GivenSuccesful()
    {
        var model = new GetByKeyWord("Title");

        var result = validator.TestValidate(model);

        Assert.True(result.IsValid);
    }
}
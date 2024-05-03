// <copyright file="UpdateSystemVariableValidatorTest.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.SystemSettings.Update;

using Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;
using Demokrata.SystemSettings.Application.Test.Configuration;
using FluentValidation.TestHelper;

/// <summary>
/// The unit test for the validators
/// </summary>
/// <seealso cref="TestFactory" />
public class UpdateSystemVariableValidatorTest : TestFactory
{
    /// <summary>
    /// The validator
    /// </summary>
    private readonly UpdateSystemVariableValidator validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSystemVariableValidatorTest"/> class.
    /// </summary>
    public UpdateSystemVariableValidatorTest() => validator = new UpdateSystemVariableValidator();

    /// <summary>
    /// Givens the maximum length of the failed key word.
    /// </summary>
    [Fact]
    public void GivenFailedKeyWordMaxLength()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            Value = "The title",
            KeyWord = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer sit amet fermentum turpis. Praesent dui lectus, tristique eget dolor sit amet, lobortis maximus ipsum. In egestas, nunc a eleifend eget."
        };

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.KeyWord);
    }

    /// <summary>
    /// Givens the failed key word required.
    /// </summary>
    [Fact]
    public void GivenFailedKeyWordRequired()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            Value = "The title"
        };

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.KeyWord);
    }

    /// <summary>
    /// Givens the failed system setting identifier required.
    /// </summary>
    [Fact]
    public void GivenFailedSystemSettingIDRequired()
    {
        var model = new UpdateSystemVariable
        {
            KeyWord = "Title",
            Value = "The title"
        };

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.SystemSettingID);
    }

    /// <summary>
    /// Givens the maximum length of the failed value.
    /// </summary>
    [Fact]
    public void GivenFailedValueMaxLength()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            Value = "The title",
            KeyWord = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec gravida convallis felis, id tincidunt magna aliquam non. In dui massa, elementum at augue ut, malesuada maximus nunc. Vivamus sodales massa ac est gravida ornare. Phasellus fermentum magna nec ex viverra, eu semper massa pretium. Mauris gravida, enim non vestibulum condimentum, ante lectus ullamcorper dui, at auctor nibh lorem nec diam. Phasellus quis auctor mi. Sed sit amet dui turpis. Vestibulum interdum ipsum nibh. Curabitur eu ligula id nisl condimentum faucibus. Integer mollis velit ullamcorper tortor porta aliquam. Sed a elit scelerisque, bibendum est quis, interdum velit. In lacus magna, imperdiet sit amet neque vel, cursus pretium neque. Etiam quis semper quam. In volutpat elementum tellus eu egestas. Vestibulum pellentesque ac mi non interdum. Aenean eget gravida lacus, venenatis consectetur nisl. Vivamus bibendum, erat in semper efficitur, nibh lectus interdum libero, sit amet ultricies sem massa eget justo. Vivamus suscipit ligula elit, vel finibus elit facilisis ac. Aliquam pulvinar nisi quis mi accumsan, a ultricies ex tincidunt. Mauris dignissim augue eu quam tempor ultrices. Pellentesque sapien augue, auctor nec semper nec, dictum sed nulla. Sed at ultricies dolor. Duis et augue non lacus dapibus lacinia et eget nunc. Fusce vulputate lacus at est hendrerit ullamcorper. Morbi tempus efficitur dolor, a sollicitudin metus. Morbi finibus nibh purus, ut volutpat libero convallis bibendum. Morbi mattis quam ex, aliquam eleifend velit auctor sit amet. In fringilla vehicula magna ut lacinia. Maecenas vel ligula vel ligula luctus suscipit vitae id erat. Pellentesque sagittis mattis diam. Nullam pellentesque, mauris pellentesque varius euismod, justo elit lacinia nisi, sit amet sodales odio tortor vel nisl. Nullam nec fermentum velit, sed porttitor nunc. Etiam convallis nunc a mattis aliquet. Aliquam eget feugiat quam, in porta erat. Vivamus non mi in est imperdiet gravida. Praesent velit massa, dictum vitae tincidunt a, sagittis nec nibh. Maecenas aliquam mi nisi. Sed pharetra, eros eget ornare vulputate, dui ante lacinia mi, eu laoreet justo nibh et ante. Ut egestas massa sed tortor pretium, quis maximus lacus vestibulum. Mauris ut pharetra dui, at maximus velit. Curabitur sollicitudin posuere odio, nec condimentum quam tempor a. Aliquam pharetra tristique lectus, placerat posuere lectus suscipit ut. Pellentesque commodo pulvinar nulla sodales ultrices. Aliquam erat volutpat. Morbi congue, enim ut volutpat malesuada, velit turpis commodo lacus, molestie aliquet turpis tortor eget urna. Donec urna tortor, convallis at faucibus ut, posuere nec enim. Sed at urna nec nibh rutrum mollis. In quis porta quam. Nam lobortis ipsum quis tincidunt convallis. Vestibulum non elit eu metus convallis elementum vitae a nunc. Cras vel vehicula nulla. In non felis tristique, dapibus odio ac, ullamcorper leo. Duis quis dictum ipsum. Nunc sagittis justo non aliquet tincidunt. Aliquam sagittis arcu mauris, et viverra nisl eleifend eu. Proin pretium tristique finibus. Curabitur odio leo, eleifend eget aliquam sed, pulvinar eu purus. Mauris molestie magna at faucibus efficitur. Mauris a convallis libero. Nulla fringilla porta pulvinar. Curabitur malesuada rhoncus consectetur. Phasellus et libero dictum, pellentesque turpis a, rutrum purus. Pellentesque feugiat eleifend ipsum eget semper. Etiam non erat elit. Fusce aliquam massa turpis, quis laoreet magna hendrerit ut. Duis pretium, est non posuere sagittis, odio justo finibus odio, quis maximus ligula metus a ex. Cras congue nec tellus a tincidunt. Vivamus ac neque orci. Pellentesque egestas diam nec ligula venenatis, scelerisque pharetra felis egestas. Ut euismod non ex sit amet tincidunt. Aenean elit nibh, ultricies ut auctor at, euismod ac tellus. Aliquam malesuada felis a arcu fringilla, ullamcorper interdum turpis feugiat. Etiam a accumsan orci. Suspendisse auctor erat vitae tellus ultricies, in tristique ante euismod nullam so"
        };

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.KeyWord);
    }

    /// <summary>
    /// Givens the failed value required.
    /// </summary>
    [Fact]
    public void GivenFailedValueRequired()
    {
        var model = new UpdateSystemVariable
        {
            SystemSettingID = 1,
            KeyWord = "Title"
        };

        var result = validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(t => t.Value);
    }

    /// <summary>
    /// Givens the succesful validations.
    /// </summary>
    [Fact]
    public void GivenSuccesfulValidations()
    {
        var model = new UpdateSystemVariable
        {
            KeyWord = "Title",
            SystemSettingID = 1,
            Value = "The title"
        };

        var result = validator.TestValidate(model);

        Assert.True(result.IsValid);
    }
}
// <copyright file="UpdateSystemVariableValidator.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;

using Demokrata.SystemSettings.Application.Common.Resources;
using FluentValidation;

/// <summary>
/// The validations to update a system variable entity
/// </summary>
/// <seealso cref="T" />
public class UpdateSystemVariableValidator : AbstractValidator<UpdateSystemVariable>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSystemVariableValidator"/> class.
    /// </summary>
    public UpdateSystemVariableValidator()
    {
        this.RuleFor(t => t.SystemSettingID)
            .NotEmpty()
            .WithMessage(CommonMessages.SystemSettingIDRequired);

        this.RuleFor(t => t.KeyWord)
            .NotEmpty()
            .WithMessage(CommonMessages.KeyWordRequired)
            .MaximumLength(200)
            .WithMessage(CommonMessages.KeyWordLength);

        this.RuleFor(t => t.Value)
            .NotEmpty()
            .WithMessage(CommonMessages.ValueRequired)
            .MaximumLength(4000)
            .WithMessage(CommonMessages.ValueLength);
    }
}
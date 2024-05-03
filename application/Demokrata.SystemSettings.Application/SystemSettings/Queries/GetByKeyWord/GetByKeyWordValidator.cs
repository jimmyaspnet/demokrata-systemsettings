// <copyright file="GetByKeyWordValidator.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;

using Demokrata.SystemSettings.Application.Common.Resources;
using FluentValidation;

/// <summary>
/// The validators to get a system setting entity
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord.GetByKeyWord&gt;" />
public class GetByKeyWordValidator : AbstractValidator<GetByKeyWord>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetByKeyWordValidator"/> class.
    /// </summary>
    public GetByKeyWordValidator()
    {
        this.RuleFor(t => t.KeyWord)
            .NotEmpty()
            .WithMessage(CommonMessages.KeyWordRequired);
    }
}
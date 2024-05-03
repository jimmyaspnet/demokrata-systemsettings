// <copyright file="GetByKeyWord.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;

using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using MediatR;

/// <summary>
/// The model to get a system setting according to its keyword field
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Demokrata.SystemSettings.Application.SystemSettings.Dtos.SystemSettingDto&gt;" />
/// <seealso cref="MediatR.IBaseRequest" />
/// <seealso cref="System.IEquatable&lt;Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord.GetByKeyWord&gt;" />
public record GetByKeyWord(string KeyWord) : IRequest<SystemSettingDto>;
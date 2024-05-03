// <copyright file="MapperConfiguration.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Common.Configuration;

using AutoMapper;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using Demokrata.SystemSettings.Domain.Entities;

/// <summary>
/// The mappers confirguration
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class MapperConfiguration : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapperConfiguration"/> class.
    /// </summary>
    public MapperConfiguration() => this.CreateMap<SystemSetting, SystemSettingDto>()
            .ForMember(dest => dest.SettingID, target => target.MapFrom(m => m.SystemSettingID));
}
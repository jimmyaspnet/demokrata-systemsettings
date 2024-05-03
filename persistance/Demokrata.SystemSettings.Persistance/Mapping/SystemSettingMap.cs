// <copyright file="SystemSettingMap.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Persistance.Mapping;

using Demokrata.SystemSettings.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// The system setting map
/// </summary>
/// <seealso cref="T" />
public class SystemSettingMap : IEntityTypeConfiguration<SystemSetting>
{
    public void Configure(EntityTypeBuilder<SystemSetting> builder)
    {
        builder.ToTable("SystemSettings");

        builder.HasKey(e => e.SystemSettingID);       

        builder.HasIndex(t => new { t.KeyWord, t.SiteID }).IsUnique();

        builder.Property(e => e.KeyWord).HasMaxLength(200);
        builder.Property(e => e.Value).HasMaxLength(4000);
        builder.Property(e => e.SiteID);
    }
}
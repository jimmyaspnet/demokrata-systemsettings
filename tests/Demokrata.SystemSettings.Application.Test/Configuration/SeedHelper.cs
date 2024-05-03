// <copyright file="SeedHelper.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.Configuration;

using Demokrata.SystemSettings.Domain.Entities;
using Demokrata.SystemSettings.Persistance.Configuration;

/// <summary>
/// The helper class to create a seed info
/// </summary>
public static class SeedHelper
{
    /// <summary>
    /// Creates a seed info.
    /// </summary>
    /// <param name="dataContext">The data context.</param>
    public static void Seed(DataContext dataContext)
    {
        var systemSettings = new SystemSetting[]
        {
            new()
            {
                KeyWord = "Title",
                Value = "This is the title",
                SiteID = 1
            },
            new() {
                KeyWord = "SettingsAllowedToChangeByAdmin",
                Value = "Title",
                SiteID = 1
            }
        };

        dataContext.SystemSettings.AddRange(systemSettings);
        dataContext.SaveChanges();
    }
}
// <copyright file="SystemSetting.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Domain.Entities;

/// <summary>
/// The system setting entity
/// </summary>
public class SystemSetting
{
    /// <summary>
    /// Gets or sets the system setting identifier.
    /// </summary>
    /// <value>
    /// The system setting identifier.
    /// </value>
    public int SystemSettingID { get; set; }

    /// <summary>
    /// Gets or sets the key word.
    /// </summary>
    /// <value>
    /// The key word.
    /// </value>
    public required string KeyWord { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public required string Value { get; set; }

    /// <summary>
    /// Gets or sets the entity identifier.
    /// </summary>
    /// <value>
    /// The entity identifier.
    /// </value>
    public int SiteID { get; set; }
}
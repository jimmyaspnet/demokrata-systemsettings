// <copyright file="SystemSettingDto.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Dtos;

/// <summary>
/// The system setting DTO
/// </summary>
/// <seealso cref="T" />
public class SystemSettingDto
{
    /// <summary>
    /// Gets or sets the setting identifier.
    /// </summary>
    /// <value>
    /// The setting identifier.
    /// </value>
    public int SettingID { get; set; }

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
}
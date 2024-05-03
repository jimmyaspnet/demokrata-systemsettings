// <copyright file="UpdateSystemVariable.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Commands.Update;

using MediatR;

/// <summary>
/// Updates the system variable
/// </summary>
public class UpdateSystemVariable : IRequest<UpdateSystemVariable>
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
    public string? KeyWord { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public string? Value { get; set; }
}
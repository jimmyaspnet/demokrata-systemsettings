// <copyright file="IDataContext.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Common.Interfaces;

using Demokrata.SystemSettings.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
/// The interface for the data context
/// </summary>
public interface IDataContext
{
    /// <summary>
    /// Gets the change tracker.
    /// </summary>
    /// <value>
    /// The change tracker.
    /// </value>
    ChangeTracker ChangeTracker { get; }

    /// <summary>
    /// Gets the database.
    /// </summary>
    /// <value>
    /// The database.
    /// </value>
    DatabaseFacade Database { get; }

    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    /// <value>
    /// The files.
    /// </value>
    DbSet<SystemSetting> SystemSettings { get; set; }


    /// <summary>
    /// Saves the changes asynchronous.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
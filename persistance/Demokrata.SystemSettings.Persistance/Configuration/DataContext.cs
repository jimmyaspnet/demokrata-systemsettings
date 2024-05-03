// <copyright file="DataContext.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Persistance.Configuration;

using System.Reflection;
using Demokrata.Core.Interfaces;
using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The data context
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class DataContext(DbContextOptions options, IWorkContext workContext) : DbContext(options), IDataContext
{
    /// <summary>
    /// The work context
    /// </summary>
    private readonly IWorkContext workContext = workContext;

    /// <summary>
    /// Gets or sets the system settings.
    /// </summary>
    /// <value>
    /// The system settings.
    /// </value>
    public DbSet<SystemSetting> SystemSettings { get; set; }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>
    /// <para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<SystemSetting>().HasQueryFilter(t => t.SiteID == this.workContext.SiteID);

        base.OnModelCreating(modelBuilder);
    }
}
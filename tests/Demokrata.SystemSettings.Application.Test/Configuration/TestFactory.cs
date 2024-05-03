// <copyright file="TestFactory.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.Test.Configuration;

using System;
using AutoMapper;
using Demokrata.Core.Interfaces;
using Demokrata.SystemSettings.Persistance.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

public abstract class TestFactory : IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestFactory"/> class.
    /// </summary>
    public TestFactory()
    {
        this.CreateDataContext();
        this.CreateMapper();
        this.CreateMediator();
    }

    /// <summary>
    /// Gets the context.
    /// </summary>
    /// <value>
    /// The context.
    /// </value>
    public DataContext Context { get; set; }

    /// <summary>
    /// Gets the mapper.
    /// </summary>
    /// <value>
    /// The mapper.
    /// </value>
    public IMapper Mapper { get; set; }

    /// <summary>
    /// Gets the mediator.
    /// </summary>
    /// <value>
    /// The mediator.
    /// </value>
    public IMediator Mediator { get; set; }

    public void Dispose()
    {
        this.Context.Dispose();
    }

    /// <summary>
    /// Creates the data context.
    /// </summary>
    private void CreateDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        var workContext = new Mock<IWorkContext>();
        workContext.Setup(s => s.SiteID).Returns(1);

        var context = new DataContext(options, workContext.Object);

        context.Database.EnsureCreated();

        this.Context = context;
    }

    /// <summary>
    /// Creates the mapper.
    /// </summary>
    private void CreateMapper()
    {
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<Common.Configuration.MapperConfiguration>();
        });

        this.Mapper = configurationProvider.CreateMapper();
    }

    /// <summary>
    /// Creates the mediator.
    /// </summary>
    private void CreateMediator()
    {
        var mediatorConfig = new Mock<IMediator>();

        mediatorConfig.Setup(m => m.Publish(It.IsAny<object>(), default));

        this.Mediator = mediatorConfig.Object;
    }
}
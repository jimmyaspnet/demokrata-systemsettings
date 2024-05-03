// <copyright file="GetSystemSettingHandler.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Queries.Get;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demokrata.Core.Models;
using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The handler to get a list of system settings
/// </summary>
/// <seealso cref="T" />
public class GetSystemSettingHandler(IDataContext dataContext, IMapper mapper) : IRequestHandler<GetSystemSetting, PagedList<SystemSettingDto>>
{
    /// <summary>
    /// The data context
    /// </summary>
    private readonly IDataContext dataContext = dataContext;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper mapper = mapper;

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Response from the request
    /// </returns>
    public async Task<PagedList<SystemSettingDto>> Handle(GetSystemSetting request, CancellationToken cancellationToken)
    {
        var query = this.dataContext.SystemSettings.AsNoTracking();

        if (request.KeyWords?.Length > 0)
        {
            query = query.Where(t => request.KeyWords.Contains(t.KeyWord));
        }

        if (!string.IsNullOrWhiteSpace(request.KeyWord))
        {
            query = query.Where(t => t.KeyWord == request.KeyWord);
        }

        return await PagedList<SystemSettingDto>.GetAsync(
            query.ProjectTo<SystemSettingDto>(this.mapper.ConfigurationProvider), 
            request.Page, 
            request.PageSize, 
            cancellationToken);
    }
}
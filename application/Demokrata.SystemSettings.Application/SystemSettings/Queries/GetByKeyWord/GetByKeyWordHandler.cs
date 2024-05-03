// <copyright file="GetByKeyWordHandler.cs" company="DonDoctor">
//     Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Jimmy Rodriguez Avila</author>
namespace Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demokrata.Core.Exceptions;
using Demokrata.SystemSettings.Application.Common.Interfaces;
using Demokrata.SystemSettings.Application.SystemSettings.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// The handler to get a system setting entity by its keyword field
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Demokrata.SystemSettings.Application.SystemSettings.Queries.GetByKeyWord.GetByKeyWord, Demokrata.SystemSettings.Application.SystemSettings.Dtos.SystemSettingDto&gt;" />
public class GetByKeyWordHandler(IDataContext dataContext, IMapper mapper) : IRequestHandler<GetByKeyWord, SystemSettingDto>
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
    /// <exception cref="Demokrata.Core.Exceptions.HttpException"></exception>
    public async Task<SystemSettingDto> Handle(GetByKeyWord request, CancellationToken cancellationToken)
    {
        var result = await this.dataContext.SystemSettings.Where(t => t.KeyWord == request.KeyWord)
            .ProjectTo<SystemSettingDto>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
        {
            throw new HttpException(System.Net.HttpStatusCode.NotFound);
        }

        return result;
    }
}
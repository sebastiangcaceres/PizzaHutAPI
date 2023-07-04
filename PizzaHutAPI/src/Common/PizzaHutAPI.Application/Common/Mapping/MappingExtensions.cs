﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaHutAPI.Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, TypeAdapterConfig configuration, CancellationToken cancellationToken)
            => queryable.ProjectToType<TDestination>(configuration).ToListAsync(cancellationToken);
    }
}
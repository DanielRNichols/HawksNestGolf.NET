﻿using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class TournamentsRepository : BaseDbResourceRepository<Tournament>, ITournamentsRepository
    {
        public TournamentsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Tournaments) {}

        public override IOrderedQueryable<Tournament> DefaultOrderBy(IQueryable<Tournament> query) => query.OrderBy(x => x.Ordinal);
        public override IList<OrderByProperties<Tournament>> GetSortOrderDefintion() => new List<OrderByProperties<Tournament>>
            {
                new OrderByProperties<Tournament> { Name = "name", OrderByFunc = x => x.Name },
                new OrderByProperties<Tournament> { Name = "ordinal", OrderByFunc = x => x.Ordinal },
                new OrderByProperties<Tournament> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

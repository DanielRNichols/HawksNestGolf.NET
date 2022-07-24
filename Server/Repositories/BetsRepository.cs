using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BetsRepository : BaseDbResourceRepository<Bet>, IBetsRepository
    {
        public BetsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Bets) {}

        public override IOrderedQueryable<Bet> OrderBy(IQueryable<Bet> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "name", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Name),
                { Name: "name", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Name),
                { Name: "defamount", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.DefAmount),
                { Name: "defamount", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.DefAmount),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Id),
                _ => DefaultOrderBy(query)
            };


        public override IOrderedQueryable<Bet> ThenBy(IOrderedQueryable<Bet> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "name", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Name),
                { Name: "name", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Name),
                { Name: "defAmount", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.DefAmount),
                { Name: "defAmount", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.DefAmount),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Id),
                _ => query
            };

    }
}

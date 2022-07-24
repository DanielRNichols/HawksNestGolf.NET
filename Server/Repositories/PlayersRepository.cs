using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class PlayersRepository : BaseDbResourceRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Players) {}
        public override IOrderedQueryable<Player> DefaultOrderBy(IQueryable<Player> query) => query.OrderBy(x => x.Name);

        public override IOrderedQueryable<Player> OrderBy(IQueryable<Player> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "name", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Name),
                { Name: "name", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Name),
                { Name: "username", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.UserName),
                { Name: "username", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.UserName),
                { Name: "email", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Email),
                { Name: "email", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Email),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Id),
                _ => DefaultOrderBy(query)
            };


        public override IOrderedQueryable<Player> ThenBy(IOrderedQueryable<Player> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "name", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Name),
                { Name: "name", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Name),
                { Name: "username", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.UserName),
                { Name: "username", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.UserName),
                { Name: "email", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Email),
                { Name: "email", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Email),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Id),
                _ => query
            };

    }
}

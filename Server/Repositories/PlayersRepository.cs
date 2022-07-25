using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class PlayersRepository : BaseDbResourceRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Players) {}
        public override IOrderedQueryable<Player> DefaultOrderBy(IQueryable<Player> query) => query.OrderBy(x => x.Name);

        public override IList<OrderByProperties<Player>> GetSortOrderDefintion() => new List<OrderByProperties<Player>>
            {
                new OrderByProperties<Player> { Name = "name", OrderByFunc = x => x.Name ?? ""},
                new OrderByProperties<Player> { Name = "username", OrderByFunc = x => x.UserName },
                new OrderByProperties<Player> { Name = "email", OrderByFunc = x => x.Email ?? ""},
                new OrderByProperties<Player> { Name = "id", OrderByFunc = x => x.Id }
            };
    }
}

using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class PlayersRepository : BaseDbResourceRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Players) {}

        public override IList<SortProperty<Player>> SortOrderDefintion() => new List<SortProperty<Player>>
            {
                new SortProperty<Player> { Name = "name", OrderByFunc = x => x.Name ?? ""},
                new SortProperty<Player> { Name = "username", OrderByFunc = x => x.UserName },
                new SortProperty<Player> { Name = "email", OrderByFunc = x => x.Email ?? ""},
                new SortProperty<Player> { Name = "id", OrderByFunc = x => x.Id }
            };
    }
}

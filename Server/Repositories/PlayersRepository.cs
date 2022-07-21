using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class PlayersRepository : BaseDbResourceRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Players) { }

    }
}

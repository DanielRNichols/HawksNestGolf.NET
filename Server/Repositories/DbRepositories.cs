using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BetsRepository : BaseDbResourceRepository<Bet>, IBetsRepository
    {
        public BetsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Bets) {}
    }

    public class TournamentsRepository : BaseDbResourceRepository<Tournament>, ITournamentsRepository
    {
        public TournamentsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Tournaments) {}

    }
    public class PlayersRepository : BaseDbResourceRepository<Player>, IPlayersRepository
    {
        public PlayersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Players) { }

    }
    public class GolfersRepository : BaseDbResourceRepository<Golfer>, IGolfersRepository
    {
        public GolfersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Golfers) { }

    }
}

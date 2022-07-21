using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BetsRepository : BaseDbResourceRepository<Bet>, IBetsRepository
    {
        public BetsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Bets) {}
    }
}

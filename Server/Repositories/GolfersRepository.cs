using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class GolfersRepository : BaseDbResourceRepository<Golfer>, IGolfersRepository
    {
        public GolfersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Golfers) { }

    }
}

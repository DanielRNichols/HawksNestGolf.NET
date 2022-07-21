using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class TournamentsRepository : BaseDbResourceRepository<Tournament>, ITournamentsRepository
    {
        public TournamentsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Tournaments) {}

    }
}

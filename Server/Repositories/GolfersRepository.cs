using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class GolfersRepository : BaseDbResourceRepository<Golfer>, IGolfersRepository
    {
        public GolfersRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Golfers) { }

        public override IList<SortProperty<Golfer>> SortOrderDefintion() => new List<SortProperty<Golfer>>
            {
                new SortProperty<Golfer> { Name = "name", OrderByFunc = x => x.Name ?? "" },
                new SortProperty<Golfer> { Name = "selectionname", OrderByFunc = x => x.SelectionName ?? "" },
                new SortProperty<Golfer> { Name = "country", OrderByFunc = x => x.Country ?? "" },
                new SortProperty<Golfer> { Name = "worldranking", OrderByFunc = x => x.WorldRanking },
                new SortProperty<Golfer> { Name = "fedexranking", OrderByFunc = x => x.FedExRanking },
                new SortProperty<Golfer> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

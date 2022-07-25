using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BetsRepository : BaseDbResourceRepository<Bet>, IBetsRepository
    {
        public BetsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Bets) {}

        public override IList<SortProperty<Bet>> SortOrderDefintion() => new List<SortProperty<Bet>>
            {
                new SortProperty<Bet> { Name = "name", OrderByFunc = x => x.Name },
                new SortProperty<Bet> { Name = "defamount", OrderByFunc = x => x.DefAmount },
                new SortProperty<Bet> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

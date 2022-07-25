using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BetsRepository : BaseDbResourceRepository<Bet>, IBetsRepository
    {
        public BetsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Bets) {}

        public override IList<OrderByProperties<Bet>> GetSortOrderDefintion() => new List<OrderByProperties<Bet>>
            {
                new OrderByProperties<Bet> { Name = "name", OrderByFunc = x => x.Name },
                new OrderByProperties<Bet> { Name = "defamount", OrderByFunc = x => x.DefAmount },
                new OrderByProperties<Bet> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

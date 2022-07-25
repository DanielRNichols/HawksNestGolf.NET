using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class TournamentsRepository : BaseDbResourceRepository<Tournament>, ITournamentsRepository
    {
        public TournamentsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Tournaments) {}

        public override IOrderedQueryable<Tournament> DefaultSort(IQueryable<Tournament> query) => query.OrderBy(x => x.Ordinal);

        public override IList<SortProperty<Tournament>> SortOrderDefintion() => new List<SortProperty<Tournament>>
            {
                new SortProperty<Tournament> { Name = "name", OrderByFunc = x => x.Name },
                new SortProperty<Tournament> { Name = "ordinal", OrderByFunc = x => x.Ordinal },
                new SortProperty<Tournament> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

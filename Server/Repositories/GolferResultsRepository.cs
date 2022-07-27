using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class GolferResultsRepository : BaseDbResourceRepository<GolferResult>, IGolferResultsRepository
    {
        public GolferResultsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.GolferResults) 
        {
        }

        public override IQueryable<GolferResult> IncludeRelated(IQueryable<GolferResult> query) =>
            query.Include(x => x.Golfer).Include(x => x.Event).Include(x => x.Event!.Tournament);

        public override IOrderedQueryable<GolferResult> DefaultSort(IQueryable<GolferResult> query) => 
            query.OrderBy(x => x.Event!.EventNo).ThenByDescending(x => x.Points).ThenBy(x => x.Id);

        public override IList<SortProperty<GolferResult>> SortOrderDefintion() => new List<SortProperty<GolferResult>>
            {
                new SortProperty<GolferResult> { Name = "golfer", OrderByFunc = x => x.Golfer!.Name ?? "" },
                new SortProperty<GolferResult> { Name = "pos", OrderByFunc = x => x.PosVal },
                new SortProperty<GolferResult> { Name = "year", OrderByFunc = x => x.Event!.Year },
                new SortProperty<GolferResult> { Name = "tournament", OrderByFunc = x => x.Event!.Tournament!.Name },
                new SortProperty<GolferResult> { Name = "id", OrderByFunc = x => x.Id },
            };

    }
}

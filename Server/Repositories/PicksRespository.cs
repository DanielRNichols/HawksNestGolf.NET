using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class PicksRespository : BaseDbResourceRepository<Pick>, IPicksRepository
    {
        public PicksRespository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Picks)
        {
        }

        public override IQueryable<Pick> IncludeRelated(IQueryable<Pick> query) =>
            query.Include(x => x.Golfer)
                 .Include(x => x.Entry)
                 .Include(x => x.Entry!.Event)
                 .Include(x => x.Entry!.Player)
                 .Include(x => x.Entry!.Event!.Tournament);


        public override IOrderedQueryable<Pick> DefaultSort(IQueryable<Pick> query) =>
            query.OrderByDescending(x => x.Entry!.Event!.EventNo).ThenBy(x => x.Entry!.PickNumber).ThenBy(x => x.Round);

        public override IList<SortProperty<Pick>> SortOrderDefintion() => new List<SortProperty<Pick>>
            {
                new SortProperty<Pick> { Name = "golfer", OrderByFunc = x => x.Golfer!.Name ?? "" },
                new SortProperty<Pick> { Name = "round", OrderByFunc = x => x.Round },
                new SortProperty<Pick> { Name = "pick", OrderByFunc = x => x.Entry!.PickNumber },
                new SortProperty<Pick> { Name = "eventno", OrderByFunc = x => x.Entry!.Event!.EventNo },
                new SortProperty<Pick> { Name = "year", OrderByFunc = x => x.Entry!.Event!.Year },
                new SortProperty<Pick> { Name = "tournament", OrderByFunc = x => x.Entry!.Event!.Tournament!.Name },
                new SortProperty<Pick> { Name = "id", OrderByFunc = x => x.Id },
            };


    }
}

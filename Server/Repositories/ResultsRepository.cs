using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class ResultsRepository : BaseDbResourceRepository<Result>, IResultsRepository
    {
        public ResultsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Results) 
        {
        }

        public override IQueryable<Result> IncludeRelated(IQueryable<Result> query) =>
            query.Include(r => r.Bet)
                 .Include(r => r.Entry)
                 .Include(r => r.Entry!.Event)
                 .Include(r => r.Entry!.Player)
                 .Include(r => r.Entry!.Event!.Tournament);

        public override IOrderedQueryable<Result> DefaultSort(IQueryable<Result> query) =>
            query.OrderByDescending(r => r.Entry!.Event!.EventNo).ThenBy(r => r.Bet!.Id);

        public override IList<SortProperty<Result>> SortOrderDefintion() => new List<SortProperty<Result>>
            {
                new SortProperty<Result> { Name = "player", OrderByFunc = x => x.Entry!.Player!.Name ?? "" },
                new SortProperty<Result> { Name = "pick", OrderByFunc = x => x.Entry!.PickNumber },
                new SortProperty<Result> { Name = "eventno", OrderByFunc = x => x.Entry!.Event!.EventNo },
                new SortProperty<Result> { Name = "year", OrderByFunc = x => x.Entry!.Event!.Year },
                new SortProperty<Result> { Name = "tournament", OrderByFunc = x => x.Entry!.Event!.Tournament!.Name },
                new SortProperty<Result> { Name = "bet", OrderByFunc = x => x.Bet!.Name },
                new SortProperty<Result> { Name = "betid", OrderByFunc = x => x.Bet!.Id },
                new SortProperty<Result> { Name = "id", OrderByFunc = x => x.Id },
            };

    }
}

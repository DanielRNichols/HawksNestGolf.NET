using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class EntriesRepository : BaseDbResourceRepository<Entry>, IEntriesRepository
    {
        public EntriesRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Entries) 
        {
        }

        public override IQueryable<Entry> IncludeRelated(IQueryable<Entry> query) =>
            query.Include(e => e.Event).Include(e => e.Player).Include(e => e.Event.Tournament);

        public override IOrderedQueryable<Entry> DefaultSort(IQueryable<Entry> query) => 
            query.OrderBy(e => e.Event.EventNo).ThenBy(e => e.PickNumber);

        public override IList<SortProperty<Entry>> SortOrderDefintion() => new List<SortProperty<Entry>>
            {
                new SortProperty<Entry> { Name = "player", OrderByFunc = x => x.Player.Name ?? "" },
                new SortProperty<Entry> { Name = "pick", OrderByFunc = x => x.PickNumber },
                new SortProperty<Entry> { Name = "eventno", OrderByFunc = x => x.Event.EventNo },
                new SortProperty<Entry> { Name = "year", OrderByFunc = x => x.Event.Year },
                new SortProperty<Entry> { Name = "tournament", OrderByFunc = x => x.Event.Tournament.Name },
                new SortProperty<Entry> { Name = "id", OrderByFunc = x => x.Id },
            };

    }
}

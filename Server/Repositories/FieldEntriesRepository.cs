using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class FieldEntriesRepository : BaseDbResourceRepository<FieldEntry>, IFieldEntriesRepository
    {
        public FieldEntriesRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.FieldEntries) 
        {
        }

        public override IQueryable<FieldEntry> IncludeRelated(IQueryable<FieldEntry> query) =>
            query.Include(e => e.Golfer);

        public override IOrderedQueryable<FieldEntry> DefaultSort(IQueryable<FieldEntry> query) => 
            query.OrderBy(e => e.Golfer!.WorldRanking);

        public override IList<SortProperty<FieldEntry>> SortOrderDefintion() => new List<SortProperty<FieldEntry>>
            {
                new SortProperty<FieldEntry> { Name = "golfer", OrderByFunc = x => x.Golfer!.Name ?? "" },
                new SortProperty<FieldEntry> { Name = "odds", OrderByFunc = x => x.OddsRank },
                new SortProperty<FieldEntry> { Name = "selectionname", OrderByFunc = x => x.Golfer!.SelectionName ?? "" },
                new SortProperty<FieldEntry> { Name = "id", OrderByFunc = x => x.Id },
            };

    }
}

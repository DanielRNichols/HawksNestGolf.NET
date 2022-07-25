using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class SortProperty<T>
    {
        public string Name { get; set; } = string.Empty;
        public Expression<Func<T, object>>? OrderByFunc { get; set; } 
    }

    public class EventsRepository : BaseDbResourceRepository<Event>, IEventsRepository
    {
        public EventsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Events)
        {
        }

        public override IQueryable<Event> IncludeRelated(IQueryable<Event> query) => query.Include(x => x.Tournament);

        public override IOrderedQueryable<Event> DefaultSort(IQueryable<Event> query) => query.OrderBy(x => x.EventNo);

        public override IList<SortProperty<Event>> SortOrderDefintion() => new List<SortProperty<Event>>
            {
                new SortProperty<Event> { Name = "eventno", OrderByFunc = x => x.EventNo },
                new SortProperty<Event> { Name = "year", OrderByFunc = x => x.Year },
                new SortProperty<Event> { Name = "tournament", OrderByFunc = x => x.Tournament.Name },
                new SortProperty<Event> { Name = "status", OrderByFunc = x => x.Status },
                new SortProperty<Event> { Name = "id", OrderByFunc = x => x.Id }
            };
    }
}

using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class OrderByProperties<T>
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
        public override IOrderedQueryable<Event> DefaultOrderBy(IQueryable<Event> query) => query.OrderBy(x => x.EventNo);

        public override IList<OrderByProperties<Event>> GetSortOrderDefintion() => new List<OrderByProperties<Event>>
            {
                new OrderByProperties<Event> { Name = "eventno", OrderByFunc = x => x.EventNo },
                new OrderByProperties<Event> { Name = "year", OrderByFunc = x => x.Year },
                new OrderByProperties<Event> { Name = "tournament", OrderByFunc = x => x.Tournament.Name },
                new OrderByProperties<Event> { Name = "status", OrderByFunc = x => x.Status },
                new OrderByProperties<Event> { Name = "id", OrderByFunc = x => x.Id }
            };
    }
}

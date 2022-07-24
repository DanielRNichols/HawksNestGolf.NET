using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class EventsRepository : BaseDbResourceRepository<Event>, IEventsRepository
    {
        private readonly HawksNestGolfDbContext _dbContext;

        public EventsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Events)
        {
            _dbContext = dbContext;
        }

        //public override async Task<IList<Event>> GetAll(QueryOptions? queryOptions = null)
        //{
        //    var query = _dbContext.Events.Select(e => e);

        //    query = ApplyQueryOptions(query, queryOptions);

        //    return await query.ToListAsync();
        //}

        public override async Task<Event?> GetById(int id)
        {
            return await _dbContext.Events.Include(e => e.Tournament).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override IQueryable<Event> IncludeRelated(IQueryable<Event> query) => query.Include(e => e.Tournament);

        public override IOrderedQueryable<Event> DefaultOrderBy(IQueryable<Event> query) => query.OrderBy(x => x.EventNo);

        public override IOrderedQueryable<Event> OrderBy(IQueryable<Event> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "eventno", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.EventNo),
                { Name: "eventno", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.EventNo),
                { Name: "year", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Year),
                { Name: "year", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Year),
                { Name: "tournament", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Tournament.Name),
                { Name: "tournament", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Tournament.Name),
                { Name: "status", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Status),
                { Name: "status", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Status),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.OrderBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.OrderByDescending(x => x.Id),
                _ => DefaultOrderBy(query)
            };


        public override IOrderedQueryable<Event> ThenBy(IOrderedQueryable<Event> query, OrderByOption orderByOption) =>
            orderByOption switch
            {
                { Name: "eventno", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.EventNo),
                { Name: "eventno", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.EventNo),
                { Name: "year", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Year),
                { Name: "year", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Year),
                { Name: "tournament", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Tournament.Name),
                { Name: "tournament", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Tournament.Name),
                { Name: "status", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Status),
                { Name: "status", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Status),
                { Name: "id", Direction: OrderByDirection.Ascending } => query.ThenBy(x => x.Id),
                { Name: "id", Direction: OrderByDirection.Descending } => query.ThenByDescending(x => x.Id),
                _ => query
            };
    }
}

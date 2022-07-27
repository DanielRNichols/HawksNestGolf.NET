using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class EventStatusRepository : BaseDbResourceRepository<EventStatus>, IEventStatusesRepository
    {
        public EventStatusRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.EventStatus)
        {
        }

        public override IList<SortProperty<EventStatus>> SortOrderDefintion() => new List<SortProperty<EventStatus>>
            {
                new SortProperty<EventStatus> { Name = "status", OrderByFunc = x => x.Status },
                new SortProperty<EventStatus> { Name = "id", OrderByFunc = x => x.Id }
            };
    }
}

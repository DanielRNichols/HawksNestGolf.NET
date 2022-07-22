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

        public override async Task<IList<Event>> GetAll()
        {
            return await _dbContext.Events.Include(e => e.Tournament).OrderByDescending(e => e.EventNo).ToListAsync();
        }

        public override async Task<Event?> GetById(int id)
        {
            return await _dbContext.Events.Include(e => e.Tournament).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

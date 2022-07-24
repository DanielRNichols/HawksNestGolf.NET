using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class EntriesRepository : BaseDbResourceRepository<Entry>, IEntriesRepository
    {
        private readonly HawksNestGolfDbContext _dbContext;

        public EntriesRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Entries) 
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<Entry>> GetAll(QueryOptions? queryOptions = null)
        {
            return await _dbContext.Entries.Include(e => e.Event)
                                           .Include(e => e.Player)
                                           .Include(e => e.Event.Tournament)
                                           .OrderBy(e => e.Event.EventNo).ThenBy(e => e.PickNumber)
                                           .ToListAsync();
        }

        public override async Task<Entry?> GetById(int id)
        {
            return await _dbContext.Entries.Include(e => e.Event)
                                           .Include(e => e.Player)
                                           .Include(e => e.Event.Tournament)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

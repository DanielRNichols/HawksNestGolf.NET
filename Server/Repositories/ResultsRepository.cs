using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class ResultsRepository : BaseDbResourceRepository<Result>, IResultsRepository
    {
        private readonly HawksNestGolfDbContext _dbContext;

        public ResultsRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Results) 
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<Result>> GetAll()
        {
            return await _dbContext.Results.Include(r => r.Bet)
                                           .Include(r => r.Entry)
                                           .Include(r => r.Entry.Event)
                                           .Include(r => r.Entry.Player)
                                           .Include(r => r.Entry.Event.Tournament)
                                           .OrderByDescending(r => r.Entry.Event.EventNo).ThenBy(r => r.Bet.Id)
                                           .ToListAsync();
        }

        public override async Task<Result?> GetById(int id)
        {
            return await _dbContext.Results.Include(r => r.Bet)
                                           .Include(r => r.Entry)
                                           .Include(r => r.Entry.Event)
                                           .Include(r => r.Entry.Player)
                                           .Include(r => r.Entry.Event.Tournament)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

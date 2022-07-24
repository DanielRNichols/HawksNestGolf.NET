using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class MessagesRepository : BaseDbResourceRepository<Message>, IMessagesRepository
    {
        private readonly HawksNestGolfDbContext _dbContext;

        public MessagesRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Messages) 
        {
            _dbContext = dbContext;
        }

        public override async Task<IList<Message>> GetAll(QueryOptions? queryOptions = null)
        {
            return await _dbContext.Messages.Include(m => m.Player).ToListAsync();
        }

        public override async Task<Message?> GetById(int id)
        {
            return await _dbContext.Messages.Include(m => m.Player).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class MessagesRepository : BaseDbResourceRepository<Message>, IMessagesRepository
    {
        public MessagesRepository(HawksNestGolfDbContext dbContext) : base(dbContext, dbContext.Messages) 
        {
        }

        public override IQueryable<Message> IncludeRelated(IQueryable<Message> query) => query.Include(x => x.Player);

        public override IList<OrderByProperties<Message>> GetSortOrderDefintion() => new List<OrderByProperties<Message>>
            {
                new OrderByProperties<Message> { Name = "content", OrderByFunc = x => x.Content ?? "" },
                new OrderByProperties<Message> { Name = "player", OrderByFunc = x => x.Player == null ? "" : x.Player.Name ?? "" },
                new OrderByProperties<Message> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

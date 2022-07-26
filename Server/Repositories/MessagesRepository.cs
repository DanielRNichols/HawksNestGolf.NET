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

        public override IList<SortProperty<Message>> SortOrderDefintion() => new List<SortProperty<Message>>
            {
                new SortProperty<Message> { Name = "content", OrderByFunc = x => x.Content ?? "" },
                new SortProperty<Message> { Name = "player", OrderByFunc = x => x.Player!.Name ?? "" },
                new SortProperty<Message> { Name = "id", OrderByFunc = x => x.Id }
            };

    }
}

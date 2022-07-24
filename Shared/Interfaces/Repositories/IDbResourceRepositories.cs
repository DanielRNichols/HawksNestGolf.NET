using HawksNestGolf.NET.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Interfaces.Repositories
{
    public interface IBetsRepository : IBaseDbResourceRepository<Bet> {}
    public interface ITournamentsRepository : IBaseDbResourceRepository<Tournament> {}
    public interface IPlayersRepository : IBaseDbResourceRepository<Player> { }
    public interface IGolfersRepository : IBaseDbResourceRepository<Golfer> { }
    public interface IMessagesRepository : IBaseDbResourceRepository<Message> { }
    public interface IEventsRepository : IBaseDbResourceRepository<Event> { }
    public interface IEntriesRepository : IBaseDbResourceRepository<Entry> { }
    public interface IResultsRepository : IBaseDbResourceRepository<Result> { }

}

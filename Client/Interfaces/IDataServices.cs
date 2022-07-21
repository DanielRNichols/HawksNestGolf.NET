using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Client.Interfaces
{
    public interface IBaseDataService<T> where T : class
    {
        Task<ApiResponse<IList<T>>> GetAll();
    }

    public interface IBetsDataService : IBaseDataService<Bet> { }
    public interface IPlayersDataService : IBaseDataService<Player> { }
    public interface ITournamentsDataService : IBaseDataService<Tournament> { }
    public interface IGolfersDataService : IBaseDataService<Golfer> { }
    public interface IMessagesDataService : IBaseDataService<Message> { }
    public interface IEventsDataService : IBaseDataService<Event> { }
}

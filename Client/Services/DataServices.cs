using HawksNestGolf.NET.Client.Interfaces;
using HawksNestGolf.NET.Shared.Models;

namespace HawksNestGolf.NET.Client.Services
{
    public class BetsDataService : BaseDataService<Bet>, IBetsDataService
    {
        public BetsDataService(HttpClient httpClient) : base(httpClient, "bets") {}
    }

    public class PlayersDataService : BaseDataService<Player>, IPlayersDataService
    {
        public PlayersDataService(HttpClient httpClient) : base(httpClient, "players") { }

    }
    public class TournamentsDataService : BaseDataService<Tournament>, ITournamentsDataService
    {
        public TournamentsDataService(HttpClient httpClient) : base(httpClient, "tournaments") { }

    }

    public class GolfersDataService : BaseDataService<Golfer>, IGolfersDataService
    {
        public GolfersDataService(HttpClient httpClient) : base(httpClient, "golfers") { }

    }

    public class MessagesDataService : BaseDataService<Message>, IMessagesDataService
    {
        public MessagesDataService(HttpClient httpClient) : base(httpClient, "messages") { }

    }

    public class EventsDataService : BaseDataService<Event>, IEventsDataService
    {
        public EventsDataService(HttpClient httpClient) : base(httpClient, "events") { }

    }
    public class EntriesDataService : BaseDataService<Entry>, IEntriesDataService
    {
        public EntriesDataService(HttpClient httpClient) : base(httpClient, "entries") { }

    }
    public class ResultsDataService : BaseDataService<Result>, IResultsDataService
    {
        public ResultsDataService(HttpClient httpClient) : base(httpClient, "results") { }

    }
}

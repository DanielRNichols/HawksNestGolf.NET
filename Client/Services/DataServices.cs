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

}

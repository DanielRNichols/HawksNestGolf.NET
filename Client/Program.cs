using HawksNestGolf.NET.Client;
using HawksNestGolf.NET.Client.Interfaces;
using HawksNestGolf.NET.Client.Services;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace HawksNestGolf.NET.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IBetsDataService, BetsDataService>();
            builder.Services.AddScoped<IPlayersDataService, PlayersDataService>();
            builder.Services.AddScoped<ITournamentsDataService, TournamentsDataService>();
            builder.Services.AddScoped<IGolfersDataService, GolfersDataService>();
            builder.Services.AddScoped<IMessagesDataService, MessagesDataService>();
            builder.Services.AddScoped<IEventsDataService, EventsDataService>();
            builder.Services.AddScoped<IEntriesDataService, EntriesDataService>();
            builder.Services.AddScoped<IResultsDataService, ResultsDataService>();
            builder.Services.AddScoped<IGolferResultsDataService, GolferResultsDataService>();
            builder.Services.AddScoped<IPicksDataService, PicksDataService>();
            builder.Services.AddScoped<IFieldEntriesDataService, FieldEntriesDataService>();

            await builder.Build().RunAsync();
        }
    }
}
using HawksNestGolf.NET.Server.Repositories;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;

namespace HawksNestGolf.NET.Server.Extensions
{
    public static class RepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBetsRepository, BetsRepository>();
            services.AddScoped<ITournamentsRepository, TournamentsRepository>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IGolfersRepository, GolfersRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IEntriesRepository, EntriesRepository>();
            services.AddScoped<IResultsRepository, ResultsRepository>();
            services.AddScoped<IGolferResultsRepository, GolferResultsRepository>();
            services.AddScoped<IPicksRepository, PicksRespository>();
            services.AddScoped<IFieldEntriesRepository, FieldEntriesRepository>();

            return services;
        }
    }
}

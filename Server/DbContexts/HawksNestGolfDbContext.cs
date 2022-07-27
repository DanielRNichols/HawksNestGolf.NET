using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.DbContexts
{
    public class HawksNestGolfDbContext : DbContext
    {
        public HawksNestGolfDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Bet> Bets => Set<Bet>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Golfer> Golfers => Set<Golfer>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Entry> Entries => Set<Entry>();
        public DbSet<Result> Results => Set<Result>();
        public DbSet<GolferResult> GolferResults => Set<GolferResult>();
        public DbSet<Pick> Picks => Set<Pick>();
        public DbSet<FieldEntry> FieldEntries => Set<FieldEntry>();
        public DbSet<EventStatus> EventStatus => Set<EventStatus>();
    }
}

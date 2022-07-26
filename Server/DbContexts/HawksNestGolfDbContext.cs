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
        public DbSet<GolferResult> EventResultGolfers => Set<GolferResult>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Player);
                //.WithMany(p => p.Messages);
            //.HasForeignKey(m => m.PlayerId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Tournament);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Event);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Player);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Bet);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Entry);
        }

    }
}

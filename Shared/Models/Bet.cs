using HawksNestGolf.NET.Shared.Interfaces.Repositories;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Bet : IDbResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefAmount { get; set; }

    }
}
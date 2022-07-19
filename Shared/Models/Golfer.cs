using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Golfer : IDbResource
    {
        public int Id { get; set; }
        public string? PGATourId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? SelectionName { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public int WorldRanking { get; set; }
        public int FedExRanking { get; set; }
        public string? Country { get; set; } = string.Empty;
    }
}

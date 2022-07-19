using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Tournament : IDbResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOfficialEvent { get; set; }
        public string? LeaderboardUrl { get; set; } = string.Empty;
        public string? LeaderboardUrl2 { get; set; } = string.Empty;
        public int Ordinal { get; set; }
    }
}

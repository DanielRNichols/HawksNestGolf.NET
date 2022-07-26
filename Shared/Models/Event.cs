using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Event : IDbResource
    {
        public int Id { get; set; }
        public int EventNo { get; set; }
        public int TournamentId { get; set; }
        public int Year { get; set; }
        public decimal EntryFee { get; set; }
        public int Status { get; set; }
        public string? Url { get; set; } = string.Empty;
        public string? Url2 { get; set; } = string.Empty;

        public Tournament? Tournament { get; set; }
    }
}

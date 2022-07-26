using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    [Table("event_results_golfers")]
    public class GolferResult : IDbResource
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int GolferId { get; set; }
        public string Position { get; set; } = string.Empty;
        public int PosVal { get; set; }
        public double Points { get; set; }

        public Event? Event { get; set; }
        public Golfer? Golfer { get; set; }

    }
}

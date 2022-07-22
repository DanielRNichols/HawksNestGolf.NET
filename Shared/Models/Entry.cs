using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Entry : IDbResource
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int PlayerId { get; set; }
        public int PickNumber { get; set; }
        public string? EntryName { get; set; } = string.Empty;

        public Event Event { get; set; } = new Event();
        public Player Player { get; set; } = new Player();
    }
}

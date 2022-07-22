using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Result : IDbResource
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public int EntryId { get; set; }
        public decimal Amount { get; set; }

        public Bet Bet { get; set; } = new Bet();
        public Entry Entry { get; set; } = new Entry();
    }
}

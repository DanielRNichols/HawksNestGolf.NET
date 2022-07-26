using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Pick : IDbResource
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public int GolferId { get; set; }
        public int Round { get; set; }

        public Entry? Entry { get; set; }
        public Golfer? Golfer { get; set; }
    }
}

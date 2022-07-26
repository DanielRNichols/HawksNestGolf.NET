using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    [Table("field")]
    public class FieldEntry : IDbResource
    {
        public int Id { get; set; }
        public int GolferId { get; set; }
        public string Odds { get; set; } = string.Empty;
        public int OddsRank { get; set; }

        public Golfer? Golfer { get; set; }
    }
}

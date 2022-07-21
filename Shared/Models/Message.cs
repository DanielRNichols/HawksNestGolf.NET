using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Message : IDbResource
    {
        [Key]
        public int Id { get; set; }
        [Column("Message")]
        public string? Content { get; set; } = string.Empty;

        public int? PlayerId { get; set; }
        public Player? Player { get; set; }

    }
}

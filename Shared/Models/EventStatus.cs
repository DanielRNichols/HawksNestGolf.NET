using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class EventStatus : IDbResource
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

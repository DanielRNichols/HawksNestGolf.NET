using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class Player : IDbResource
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Email2 { get; set; } = string.Empty;
        public bool? IsAdmin { get; set; }
        public DateTime? LastAccess { get; set; }
    }
}

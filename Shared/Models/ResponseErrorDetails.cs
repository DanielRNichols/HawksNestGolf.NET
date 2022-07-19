using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class ResponseErrorDetails
    {
        public int StatusCode { get; set; }
        public string Details { get; set; } = string.Empty;
        public string TraceId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}

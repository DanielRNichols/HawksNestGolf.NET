using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Models
{
    public class SortProperty<T>
    {
        public string Name { get; set; } = string.Empty;
        public Expression<Func<T, object>>? OrderByFunc { get; set; }
    }
}

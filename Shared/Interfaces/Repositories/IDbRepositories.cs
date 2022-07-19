using HawksNestGolf.NET.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Interfaces.Repositories
{
    public interface IBetsRepository : IBaseDbResourceRepository<Bet> {}
    public interface ITournamentsRepository : IBaseDbResourceRepository<Tournament> {}

}

using HawksNestGolf.NET.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawksNestGolf.NET.Shared.Interfaces.Repositories
{
    public interface IBaseDbResourceRepository<T> where T : class,IDbResource
    {
        Task<IList<T>> GetAll(QueryOptions? queryOptions = null);
        Task<T?> GetById(int id, bool includeRelated = true);
        Task<T?> Add(T item);
        Task<T?> Update(T item);
        Task<bool> Delete(int id);

    }
}

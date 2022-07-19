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
        Task<IList<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T?> Add(T item);
        Task<T?> Update(T item);
        Task<bool> Delete(int id);

    }
}

using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
using HawksNestGolf.NET.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HawksNestGolf.NET.Server.Repositories
{
    public class BaseDbResourceRepository<T> where T : class, IDbResource, new()
    {
        private readonly HawksNestGolfDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseDbResourceRepository(HawksNestGolfDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public virtual async Task<IList<T>> GetAll(QueryOptions? queryOptions = null)
        {
            var query = _dbSet.Select(t => t);

            query = ApplyQueryOptions(query, queryOptions);

            return await query.ToListAsync();
        }

        private IQueryable<T> ApplyQueryOptions(IQueryable<T> query, QueryOptions? queryOptions)
        {
            if (queryOptions is not null && queryOptions.IncludeRelated)
                query = IncludeRelated(query);

            query = SetOrder(query, queryOptions?.OrderBy);

            if (queryOptions is not null && queryOptions.Skip > 0)
                query = query.Skip(queryOptions.Skip);

            if (queryOptions is not null && queryOptions.Take > 0)
                query = query.Take(queryOptions.Take);

            return query;
        }

        public virtual IQueryable<T> IncludeRelated(IQueryable<T> query) => query;

        public virtual IQueryable<T> SetOrder(IQueryable<T> query, OrderByOption[]? orderBy)
        {
            if (orderBy is not null && orderBy.Length > 0)
            {
                var orderedQuery = OrderBy(query, orderBy[0]);
                for (int i = 1; i < orderBy.Length; i++)
                {
                    orderedQuery = ThenBy(orderedQuery, orderBy[i]);
                }
                query = orderedQuery;

                return query;

            }
            
            return DefaultOrderBy(query);
        }

        public virtual IOrderedQueryable<T> OrderBy(IQueryable<T> query, OrderByOption option) => DefaultOrderBy(query);

        public virtual IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> orderedQuery, OrderByOption option) => orderedQuery;

        public virtual IOrderedQueryable<T> DefaultOrderBy(IQueryable<T> query) => query.OrderBy(x => x.Id);

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T?> Add(T item)
        {
            await _dbSet.AddAsync(item);
            bool success = await Save();
            if (!success)
                return null;

            return item;
        }

        public virtual async Task<T?> Update(T item)
        {
            _dbSet.Update(item);
            bool success = await Save();
            if (!success)
                return null;

            return item;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var item = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (item is null)
                return false;

            _dbSet.Remove(item);
            return await Save();
        }


        private async Task<bool> Save()
        {
            var changes = await _dbContext.SaveChangesAsync();

            return changes > 0;
        }

    }
}

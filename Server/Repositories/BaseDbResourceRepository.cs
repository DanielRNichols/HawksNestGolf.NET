using HawksNestGolf.NET.Server.DbContexts;
using HawksNestGolf.NET.Shared.Interfaces.Repositories;
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

        public virtual async Task<IList<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

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

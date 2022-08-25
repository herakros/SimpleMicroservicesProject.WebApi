using CustomerMicroservice.Contracts.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly CustomerDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByKeyAsync<TKey>(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbContext.Entry(entity).State = EntityState.Modified);
        }
    }
}

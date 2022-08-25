using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;

namespace ProductMicroservice.Data
{
    public class ProductRepository : IRepository
    {   
        protected readonly ProductDbContext _db;
        protected readonly DbSet<Product> _dbProduct;
        public ProductRepository(ProductDbContext productDb)
        {
            _db = productDb;
            _dbProduct = _db.Set<Product>();
        }
        public async Task<Product> AddAsync(Product entity)
        {
            return (await _dbProduct.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Product entity)
        {
            await Task.Run(() => _dbProduct.Remove(entity));
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbProduct.ToListAsync();
        }

        public async Task<Product> GetByKeyAsync(int key)
        {
            return await _dbProduct.FindAsync(key);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            await Task.Run(() => _db.Entry(entity).State = EntityState.Modified);
        }
    }
}

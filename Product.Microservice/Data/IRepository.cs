using ProductMicroservice.Models;

namespace ProductMicroservice.Data
{
    public interface IRepository
    {
        Task<Product> AddAsync(Product entity);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByKeyAsync(int key);

        Task UpdateAsync(Product entity);

        Task DeleteAsync(Product entity);

        Task<int> SaveChangesAsync();
    }
}

using CustomerMicroservice.Contracts.Data.Entities;
using CustomerMicroservice.Contracts.DTO;

namespace CustomerMicroservice.Contracts.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task DeleteCustomerAsync(int id);

        Task<Customer> GetCustomerByIdAsync(int id);

        Task UpdateCustomerAsync(UpdateCustomerDTO model, int id);
    }
}

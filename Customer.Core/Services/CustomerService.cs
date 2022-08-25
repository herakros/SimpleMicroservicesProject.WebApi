using CustomerMicroservice.Contracts.Data;
using CustomerMicroservice.Contracts.Data.Entities;
using CustomerMicroservice.Contracts.DTO;
using CustomerMicroservice.Contracts.Services;

namespace CustomerMicroservice.Core.Services
{
    public class CustomerService : ICustomerService
    {
        protected readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByKeyAsync(id);

            if(customer != null)
            {
                await _customerRepository.DeleteAsync(customer);
                await _customerRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByKeyAsync(id);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDTO model, int id)
        {
            var customer = await _customerRepository.GetByKeyAsync(id);

            if(customer != null)
            {
                customer.Age = model.Age;
                customer.Name = model.Name;
                customer.SecondName = model.SecondName;

                await _customerRepository.UpdateAsync(customer);
                await _customerRepository.SaveChangesAsync();
            }
        }
    }
}

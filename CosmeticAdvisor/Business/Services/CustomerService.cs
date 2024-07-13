using CosmeticAdvisor.Models;
using CosmeticAdvisor.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _repository.GetCustomers();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _repository.GetCustomer(id);
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _repository.CreateCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _repository.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _repository.DeleteCustomer(id);
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
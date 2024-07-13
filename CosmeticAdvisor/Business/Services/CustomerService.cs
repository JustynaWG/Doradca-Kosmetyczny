using System.Collections.Generic;
using System.Threading.Tasks;
using CosmeticAdvisor.DTO;
using CosmeticAdvisor.Repositories;

namespace CosmeticAdvisor.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
        {
            return await _customerRepository.CreateCustomerAsync(customerDto);
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto customerDto)
        {
            return await _customerRepository.UpdateCustomerAsync(customerDto);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
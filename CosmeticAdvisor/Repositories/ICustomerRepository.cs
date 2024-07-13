using CosmeticAdvisor.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto);
        Task<bool> UpdateCustomerAsync(CustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}


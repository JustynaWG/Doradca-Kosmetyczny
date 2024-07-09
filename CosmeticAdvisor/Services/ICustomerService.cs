using CosmeticAdvisor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
using CosmeticAdvisor.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var query = "SELECT * FROM Customers";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Customer>(query);
            }
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var query = "SELECT * FROM Customers WHERE CustomerId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Customer>(query, new { Id = id });
            }
        }

        public async Task CreateCustomer(Customer customer)
        {
            var query = "INSERT INTO Customers (Name, Email, SkinType) VALUES (@Name, @Email, @SkinType)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, customer);
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var query = "UPDATE Customers SET Name = @Name, Email = @Email, SkinType = @SkinType WHERE CustomerId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, customer);
            }
        }

        public async Task DeleteCustomer(int id)
        {
            var query = "DELETE FROM Customers WHERE CustomerId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
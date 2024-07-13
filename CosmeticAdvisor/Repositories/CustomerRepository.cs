using CosmeticAdvisor.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var query = "SELECT * FROM Customers";
            return await _dbConnection.QueryAsync<CustomerDto>(query);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var query = "SELECT * FROM Customers WHERE CustomerId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<CustomerDto>(query, new { Id = id });
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
        {
            var query = "INSERT INTO Customers (Name, Email, SkinType) VALUES (@Name, @Email, @SkinType); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, customerDto);
            customerDto.CustomerId = id;
            return customerDto;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto customerDto)
        {
            var query = "UPDATE Customers SET Name = @Name, Email = @Email, SkinType = @SkinType WHERE CustomerId = @CustomerId";
            var result = await _dbConnection.ExecuteAsync(query, customerDto);
            return result > 0;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var query = "DELETE FROM Customers WHERE CustomerId = @Id";
            var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }
    }
}
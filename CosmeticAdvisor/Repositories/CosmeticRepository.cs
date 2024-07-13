using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using CosmeticAdvisor.DTO;

namespace CosmeticAdvisor.Repositories
{
    public class CosmeticRepository : ICosmeticRepository
    {
        private readonly IDbConnection _dbConnection;

        public CosmeticRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CosmeticDto>> GetAllCosmeticsAsync()
        {
            var query = "SELECT * FROM Cosmetics";
            return await _dbConnection.QueryAsync<CosmeticDto>(query);
        }

        public async Task<CosmeticDto> GetCosmeticByIdAsync(int id)
        {
            var query = "SELECT * FROM Cosmetics WHERE CosmeticId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<CosmeticDto>(query, new { Id = id });
        }

        public async Task<CosmeticDto> CreateCosmeticAsync(CosmeticDto cosmeticDto)
        {
            var query = "INSERT INTO Cosmetics (Name, Brand, Category, SkinType) VALUES (@Name, @Brand, @Category, @SkinType); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, cosmeticDto);
            cosmeticDto.CosmeticId = id;
            return cosmeticDto;
        }

        public async Task<bool> UpdateCosmeticAsync(CosmeticDto cosmeticDto)
        {
            var query = "UPDATE Cosmetics SET Name = @Name, Brand = @Brand, Category = @Category, SkinType = @SkinType WHERE CosmeticId = @CosmeticId";
            var result = await _dbConnection.ExecuteAsync(query, cosmeticDto);
            return result > 0;
        }

        public async Task<bool> DeleteCosmeticAsync(int id)
        {
            var query = "DELETE FROM Cosmetics WHERE CosmeticId = @Id";
            var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }
    }
}

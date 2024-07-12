
using CosmeticAdvisor.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public class CosmeticRepository : ICosmeticRepository
    {
        private readonly DapperContext _context;

        public CosmeticRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cosmetic>> GetCosmetics()
        {
            var query = "SELECT * FROM Cosmetics";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Cosmetic>(query);
            }
        }

        public async Task<Cosmetic> GetCosmetic(int id)
        {
            var query = "SELECT * FROM Cosmetics WHERE CosmeticId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Cosmetic>(query, new { Id = id });
            }
        }

        public async Task CreateCosmetic(Cosmetic cosmetic)
        {
            var query = "INSERT INTO Cosmetics (Name, Description, Ingredients, SkinType) VALUES (@Name, @Description, @Ingredients, @SkinType)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, cosmetic);
            }
        }

        public async Task UpdateCosmetic(Cosmetic cosmetic)
        {
            var query = "UPDATE Cosmetics SET Name = @Name, Description = @Description, Ingredients = @Ingredients, SkinType = @SkinType WHERE CosmeticId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, cosmetic);
            }
        }

        public async Task DeleteCosmetic(int id)
        {
            var query = "DELETE FROM Cosmetics WHERE CosmeticId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
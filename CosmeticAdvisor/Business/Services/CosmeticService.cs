using CosmeticAdvisor.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Business.Services
{
    public class CosmeticService : ICosmeticService
    {
        private readonly DapperContext _context;

        public CosmeticService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cosmetic>> GetAllCosmetics()
        {
            using var connection = _context.CreateConnection();
            var cosmetics = await connection.QueryAsync<Cosmetic>("SELECT * FROM Cosmetics");
            return cosmetics;
        }

        public async Task<Cosmetic> GetCosmeticById(int id)
        {
            using var connection = _context.CreateConnection();
            var cosmetic = await connection.QueryFirstOrDefaultAsync<Cosmetic>("SELECT * FROM Cosmetics WHERE CosmeticId = @Id", new { Id = id });
            return cosmetic;
        }

        public async Task CreateCosmetic(Cosmetic cosmetic)
        {
            using var connection = _context.CreateConnection();
            var sql = @"INSERT INTO Cosmetics (Name, Brand, Type) VALUES (@Name, @Brand, @Type)";
            await connection.ExecuteAsync(sql, cosmetic);
        }

        public async Task UpdateCosmetic(Cosmetic cosmetic)
        {
            using var connection = _context.CreateConnection();
            var sql = @"UPDATE Cosmetics SET Name = @Name, Brand = @Brand, Type = @Type WHERE CosmeticId = @CosmeticId";
            await connection.ExecuteAsync(sql, cosmetic);
        }

        public async Task DeleteCosmetic(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"DELETE FROM Cosmetics WHERE CosmeticId = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
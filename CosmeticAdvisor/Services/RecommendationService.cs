using CosmeticAdvisor.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly DapperContext _context;

        public RecommendationService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recommendation>> GetAllRecommendations()
        {
            using var connection = _context.CreateConnection();
            var recommendations = await connection.QueryAsync<Recommendation>("SELECT * FROM Recommendations");
            return recommendations;
        }

        public async Task<Recommendation> GetRecommendationById(int id)
        {
            using var connection = _context.CreateConnection();
            var recommendation = await connection.QueryFirstOrDefaultAsync<Recommendation>("SELECT * FROM Recommendations WHERE RecommendationId = @Id", new { Id = id });
            return recommendation;
        }

        public async Task CreateRecommendation(Recommendation recommendation)
        {
            using var connection = _context.CreateConnection();
            var sql = @"INSERT INTO Recommendations (Title, Description) VALUES (@Title, @Description)";
            await connection.ExecuteAsync(sql, recommendation);
        }

        public async Task UpdateRecommendation(Recommendation recommendation)
        {
            using var connection = _context.CreateConnection();
            var sql = @"UPDATE Recommendations SET Title = @Title, Description = @Description WHERE RecommendationId = @RecommendationId";
            await connection.ExecuteAsync(sql, recommendation);
        }

        public async Task DeleteRecommendation(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"DELETE FROM Recommendations WHERE RecommendationId = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

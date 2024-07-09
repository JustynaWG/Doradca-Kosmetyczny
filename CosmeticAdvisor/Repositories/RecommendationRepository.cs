using CosmeticAdvisor.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly DapperContext _context;

        public RecommendationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendations()
        {
            var query = "SELECT * FROM Recommendations";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Recommendation>(query);
            }
        }

        public async Task<Recommendation> GetRecommendation(int id)
        {
            var query = "SELECT * FROM Recommendations WHERE RecommendationId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Recommendation>(query, new { Id = id });
            }
        }

        public async Task CreateRecommendation(Recommendation recommendation)
        {
            var query = "INSERT INTO Recommendations (CustomerId, CosmeticId, RecommendedOn) VALUES (@CustomerId, @CosmeticId, @RecommendedOn)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, recommendation);
            }
        }

        public async Task UpdateRecommendation(Recommendation recommendation)
        {
            var query = "UPDATE Recommendations SET CustomerId = @CustomerId, CosmeticId = @CosmeticId, RecommendedOn = @RecommendedOn WHERE RecommendationId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, recommendation);
            }
        }

        public async Task DeleteRecommendation(int id)
        {
            var query = "DELETE FROM Recommendations WHERE RecommendationId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}


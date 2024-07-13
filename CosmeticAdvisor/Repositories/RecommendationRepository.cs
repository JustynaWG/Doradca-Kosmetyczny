using CosmeticAdvisor.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly IDbConnection _dbConnection;

        public RecommendationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync()
        {
            var query = "SELECT * FROM Recommendations";
            return await _dbConnection.QueryAsync<RecommendationDto>(query);
        }

        public async Task<RecommendationDto> GetRecommendationByIdAsync(int id)
        {
            var query = "SELECT * FROM Recommendations WHERE RecommendationId = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<RecommendationDto>(query, new { Id = id });
        }

        public async Task<RecommendationDto> CreateRecommendationAsync(RecommendationDto recommendationDto)
        {
            var query = "INSERT INTO Recommendations (CustomerId, CosmeticId, Notes, RecommendedDate) VALUES (@CustomerId, @CosmeticId, @Notes, @RecommendedDate); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, recommendationDto);
            recommendationDto.RecommendationId = id;
            return recommendationDto;
        }

        public async Task<bool> UpdateRecommendationAsync(RecommendationDto recommendationDto)
        {
            var query = "UPDATE Recommendations SET CustomerId = @CustomerId, CosmeticId = @CosmeticId, Notes = @Notes, RecommendedDate = @RecommendedDate WHERE RecommendationId = @RecommendationId";
            var result = await _dbConnection.ExecuteAsync(query, recommendationDto);
            return result > 0;
        }

        public async Task<bool> DeleteRecommendationAsync(int id)
        {
            var query = "DELETE FROM Recommendations WHERE RecommendationId = @Id";
            var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }
    }
}

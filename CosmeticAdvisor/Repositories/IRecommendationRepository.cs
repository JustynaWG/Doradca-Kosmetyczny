using CosmeticAdvisor.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync();
        Task<RecommendationDto> GetRecommendationByIdAsync(int id);
        Task<RecommendationDto> CreateRecommendationAsync(RecommendationDto recommendationDto);
        Task<bool> UpdateRecommendationAsync(RecommendationDto recommendationDto);
        Task<bool> DeleteRecommendationAsync(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmeticAdvisor.DTO;
using CosmeticAdvisor.Repositories;

namespace CosmeticAdvisor.Business
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync()
        {
            return await _recommendationRepository.GetAllRecommendationsAsync();
        }

        public async Task<RecommendationDto> GetRecommendationByIdAsync(int id)
        {
            return await _recommendationRepository.GetRecommendationByIdAsync(id);
        }

        public async Task<RecommendationDto> CreateRecommendationAsync(RecommendationDto recommendationDto)
        {
            return await _recommendationRepository.CreateRecommendationAsync(recommendationDto);
        }

        public async Task<bool> UpdateRecommendationAsync(RecommendationDto recommendationDto)
        {
            return await _recommendationRepository.UpdateRecommendationAsync(recommendationDto);
        }

        public async Task<bool> DeleteRecommendationAsync(int id)
        {
            return await _recommendationRepository.DeleteRecommendationAsync(id);
        }
    }
}
using CosmeticAdvisor.Models;
using CosmeticAdvisor.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _repository;

        public RecommendationService(IRecommendationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Recommendation>> GetRecommendations()
        {
            return await _repository.GetRecommendations();
        }

        public async Task<Recommendation> GetRecommendation(int id)
        {
            return await _repository.GetRecommendation(id);
        }

        public async Task CreateRecommendation(Recommendation recommendation)
        {
            await _repository.CreateRecommendation(recommendation);
        }

        public async Task UpdateRecommendation(Recommendation recommendation)
        {
            await _repository.UpdateRecommendation(recommendation);
        }

        public async Task DeleteRecommendation(int id)
        {
            await _repository.DeleteRecommendation(id);
        }
    }
}


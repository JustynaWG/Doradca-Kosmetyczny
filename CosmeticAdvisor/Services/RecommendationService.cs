using CosmeticAdvisor.Models;

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
            // Implementation of the method
        }

        public async Task<Recommendation> GetRecommendationById(int id)
        {
            // Implementation of the method
        }

        public async Task CreateRecommendation(Recommendation recommendation)
        {
            // Implementation of the method
        }

        public async Task UpdateRecommendation(Recommendation recommendation)
        {
            // Implementation of the method
        }

        public async Task DeleteRecommendation(int id)
        {
            // Implementation of the method
        }
    }
}


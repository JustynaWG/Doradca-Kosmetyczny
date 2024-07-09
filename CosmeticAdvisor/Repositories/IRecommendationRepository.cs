using CosmeticAdvisor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<Recommendation>> GetRecommendations();
        Task<Recommendation> GetRecommendation(int id);
        Task CreateRecommendation(Recommendation recommendation);
        Task UpdateRecommendation(Recommendation recommendation);
        Task DeleteRecommendation(int id);
    }
}
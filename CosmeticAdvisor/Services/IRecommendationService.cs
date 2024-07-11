using CosmeticAdvisor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Services
{
    public interface IRecommendationService
    {
        Task<IEnumerable<Recommendation>> GetAllRecommendations();
        Task<Recommendation> GetRecommendationById(int id);
        Task CreateRecommendation(Recommendation recommendation);
        Task UpdateRecommendation(Recommendation recommendation);
        Task DeleteRecommendation(int id);
    }
}
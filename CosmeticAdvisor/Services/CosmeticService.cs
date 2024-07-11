using CosmeticAdvisor.Models;

namespace CosmeticAdvisor.Services
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
            // Implementation of the method
        }

        public async Task<Cosmetic> GetCosmeticById(int id)
        {
            // Implementation of the method
        }

        public async Task CreateCosmetic(Cosmetic cosmetic)
        {
            // Implementation of the method
        }

        public async Task UpdateCosmetic(Cosmetic cosmetic)
        {
            // Implementation of the method
        }

        public async Task DeleteCosmetic(int id)
        {
            // Implementation of the method
        }
    }
}



using CosmeticAdvisor.Models;
using CosmeticAdvisor.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Services
{
    public class CosmeticService : ICosmeticService
    {
        private readonly ICosmeticRepository _repository;

        public CosmeticService(ICosmeticRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cosmetic>> GetCosmetics()
        {
            return await _repository.GetCosmetics();
        }

        public async Task<Cosmetic> GetCosmetic(int id)
        {
            return await _repository.GetCosmetic(id);
        }

        public async Task CreateCosmetic(Cosmetic cosmetic)
        {
            await _repository.CreateCosmetic(cosmetic);
        }

        public async Task UpdateCosmetic(Cosmetic cosmetic)
        {
            await _repository.UpdateCosmetic(cosmetic);
        }

        public async Task DeleteCosmetic(int id)
        {
            await _repository.DeleteCosmetic(id);
        }
    }
}


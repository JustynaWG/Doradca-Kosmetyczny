using System.Collections.Generic;
using System.Threading.Tasks;
using CosmeticAdvisor.DTO;
using CosmeticAdvisor.Repositories;

namespace CosmeticAdvisor.Business
{
    public class CosmeticService : ICosmeticService
    {
        private readonly ICosmeticRepository _cosmeticRepository;

        public CosmeticService(ICosmeticRepository cosmeticRepository)
        {
            _cosmeticRepository = cosmeticRepository;
        }

        public async Task<IEnumerable<CosmeticDto>> GetAllCosmeticsAsync()
        {
            return await _cosmeticRepository.GetAllCosmeticsAsync();
        }

        public async Task<CosmeticDto> GetCosmeticByIdAsync(int id)
        {
            return await _cosmeticRepository.GetCosmeticByIdAsync(id);
        }

        public async Task<CosmeticDto> CreateCosmeticAsync(CosmeticDto cosmeticDto)
        {
            return await _cosmeticRepository.CreateCosmeticAsync(cosmeticDto);
        }

        public async Task<bool> UpdateCosmeticAsync(CosmeticDto cosmeticDto)
        {
            return await _cosmeticRepository.UpdateCosmeticAsync(cosmeticDto);
        }

        public async Task<bool> DeleteCosmeticAsync(int id)
        {
            return await _cosmeticRepository.DeleteCosmeticAsync(id);
        }
    }
}
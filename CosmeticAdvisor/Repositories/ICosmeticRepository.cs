using System.Collections.Generic;
using System.Threading.Tasks;
using CosmeticAdvisor.DTO;

namespace CosmeticAdvisor.Repositories
{
    public interface ICosmeticRepository
    {
        Task<IEnumerable<CosmeticDto>> GetAllCosmeticsAsync();
        Task<CosmeticDto> GetCosmeticByIdAsync(int id);
        Task<CosmeticDto> CreateCosmeticAsync(CosmeticDto cosmeticDto);
        Task<bool> UpdateCosmeticAsync(CosmeticDto cosmeticDto);
        Task<bool> DeleteCosmeticAsync(int id);
    }
}
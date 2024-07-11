namespace CosmeticAdvisor.Services
{
    public interface ICosmeticService
    {
        Task<IEnumerable<Cosmetic>> GetAllCosmetics();
        Task<Cosmetic> GetCosmeticById(int id);
        Task CreateCosmetic(Cosmetic cosmetic);
        Task UpdateCosmetic(Cosmetic cosmetic);
        Task DeleteCosmetic(int id);
    }
}
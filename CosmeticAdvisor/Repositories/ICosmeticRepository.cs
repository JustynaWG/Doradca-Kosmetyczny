﻿using CosmeticAdvisor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmeticAdvisor.Repositories
{
    public interface ICosmeticRepository
    {
        Task<IEnumerable<Cosmetic>> GetCosmetics();
        Task<Cosmetic> GetCosmetic(int id);
        Task CreateCosmetic(Cosmetic cosmetic);
        Task UpdateCosmetic(Cosmetic cosmetic);
        Task DeleteCosmetic(int id);
    }
}


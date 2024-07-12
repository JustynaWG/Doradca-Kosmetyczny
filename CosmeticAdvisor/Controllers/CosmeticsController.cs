using Microsoft.AspNetCore.Mvc;
using CosmeticAdvisor.Models;
using CosmeticAdvisor.Services;

namespace CosmeticAdvisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmeticsController : ControllerBase
    {
        private readonly ICosmeticService _cosmeticService;

        public CosmeticsController(ICosmeticService cosmeticService)
        {
            _cosmeticService = cosmeticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCosmetics()
        {
            var cosmetics = await _cosmeticService.GetAllCosmetics();
            return Ok(cosmetics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCosmetic(int id)
        {
            var cosmetic = await _cosmeticService.GetCosmeticById(id);
            if (cosmetic == null)
            {
                return NotFound();
            }
            return Ok(cosmetic);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCosmetic(Cosmetic cosmetic)
        {
            await _cosmeticService.CreateCosmetic(cosmetic);
            return CreatedAtAction(nameof(GetCosmetic), new { id = cosmetic.CosmeticId }, cosmetic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCosmetic(int id, Cosmetic cosmetic)
        {
            if (id != cosmetic.CosmeticId)
            {
                return BadRequest();
            }
            await _cosmeticService.UpdateCosmetic(cosmetic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCosmetic(int id)
        {
            await _cosmeticService.DeleteCosmetic(id);
            return NoContent();
        }
    }
}
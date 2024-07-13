using Microsoft.AspNetCore.Mvc;
using CosmeticAdvisor.DTO;
using CosmeticAdvisor.Business;

namespace CosmeticAdvisor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CosmeticsController : ControllerBase
    {
        private readonly ICosmeticService _cosmeticService;

        public CosmeticsController(ICosmeticService cosmeticService)
        {
            _cosmeticService = cosmeticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCosmetics()
        {
            var cosmetics = await _cosmeticService.GetAllCosmeticsAsync();
            return Ok(cosmetics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCosmeticById(int id)
        {
            var cosmetic = await _cosmeticService.GetCosmeticByIdAsync(id);
            if (cosmetic == null)
            {
                return NotFound();
            }
            return Ok(cosmetic);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCosmetic([FromBody] CosmeticDto cosmeticDto)
        {
            if (cosmeticDto == null)
            {
                return BadRequest();
            }

            var createdCosmetic = await _cosmeticService.CreateCosmeticAsync(cosmeticDto);
            return CreatedAtAction(nameof(GetCosmeticById), new { id = createdCosmetic.CosmeticId }, createdCosmetic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCosmetic(int id, [FromBody] CosmeticDto cosmeticDto)
        {
            if (cosmeticDto == null || id != cosmeticDto.CosmeticId)
            {
                return BadRequest();
            }

            var result = await _cosmeticService.UpdateCosmeticAsync(cosmeticDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCosmetic(int id)
        {
            var result = await _cosmeticService.DeleteCosmeticAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

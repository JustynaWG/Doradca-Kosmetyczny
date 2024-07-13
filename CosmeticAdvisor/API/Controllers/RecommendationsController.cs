using CosmeticAdvisor.Business;
using CosmeticAdvisor.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticAdvisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecommendationDto>>> GetAllRecommendations()
        {
            var recommendations = await _recommendationService.GetAllRecommendationsAsync();
            return Ok(recommendations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendationDto>> GetRecommendationById(int id)
        {
            var recommendation = await _recommendationService.GetRecommendationByIdAsync(id);
            if (recommendation == null)
            {
                return NotFound();
            }
            return Ok(recommendation);
        }

        [HttpPost]
        public async Task<ActionResult<RecommendationDto>> CreateRecommendation(RecommendationDto recommendationDto)
        {
            var createdRecommendation = await _recommendationService.CreateRecommendationAsync(recommendationDto);
            return CreatedAtAction(nameof(GetRecommendationById), new { id = createdRecommendation.RecommendationId }, createdRecommendation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, RecommendationDto recommendationDto)
        {
            if (id != recommendationDto.RecommendationId)
            {
                return BadRequest();
            }

            var result = await _recommendationService.UpdateRecommendationAsync(recommendationDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            var result = await _recommendationService.DeleteRecommendationAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}




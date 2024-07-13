using Microsoft.AspNetCore.Mvc;
using CosmeticAdvisor.Models;
using CosmeticAdvisor.Business.Services;

namespace CosmeticAdvisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecommendations()
        {
            var recommendations = await _recommendationService.GetAllRecommendations();
            return Ok(recommendations);
        }
            
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecommendation(int id)
        {
            var recommendation = await _recommendationService.GetRecommendationById(id);
            if (recommendation == null)
            {
                return NotFound();
            }
            return Ok(recommendation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecommendation(Recommendation recommendation)
        {
            await _recommendationService.CreateRecommendation(recommendation);
            return CreatedAtAction(nameof(GetRecommendation), new { id = recommendation.RecommendationId }, recommendation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, Recommendation recommendation)
        {
            if (id != recommendation.RecommendationId)
            {
                return BadRequest();
            }
            await _recommendationService.UpdateRecommendation(recommendation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            await _recommendationService.DeleteRecommendation(id);
            return NoContent();
        }
    }
}



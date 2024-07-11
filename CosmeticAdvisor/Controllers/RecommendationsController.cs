using Microsoft.AspNetCore.Mvc;
using CosmeticAdvisor.Models;
using CosmeticAdvisor.Services;

namespace CosmeticAdvisor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recommendations = await _recommendationService.GetAllRecommendations();
            return Ok(recommendations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recommendation = await _recommendationService.GetRecommendationById(id);
            if (recommendation == null)
            {
                return NotFound();
            }
            return Ok(recommendation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recommendation recommendation)
        {
            await _recommendationService.CreateRecommendation(recommendation);
            return CreatedAtAction(nameof(GetById), new { id = recommendation.RecommendationId }, recommendation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Recommendation recommendation)
        {
            if (id != recommendation.RecommendationId)
            {
                return BadRequest();
            }

            await _recommendationService.UpdateRecommendation(recommendation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _recommendationService.DeleteRecommendation(id);
            return NoContent();
        }
    }
}
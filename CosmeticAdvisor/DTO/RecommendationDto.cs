using System;

namespace CosmeticAdvisor.DTO
{
    public class RecommendationDto
    {
        public int RecommendationId { get; set; }
        public int CustomerId { get; set; }
        public int CosmeticId { get; set; }
        public string Notes { get; set; }
        public DateTime RecommendedDate { get; set; }
    }
}


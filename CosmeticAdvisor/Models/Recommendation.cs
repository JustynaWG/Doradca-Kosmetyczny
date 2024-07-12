namespace CosmeticAdvisor.Models;
public class Recommendation
{
    public int RecommendationId { get; set; }
    public int CustomerId { get; set; }
    public int CosmeticId { get; set; }
    public string? Notes { get; set; }
}

namespace ShelterApi.DTOs
{
    public class ShelterLatestInspectionDto
    {
        public int? ShelterId { get; set; }
        public string? ShelterName { get; set; } = string.Empty;
        public DateTime? LatestInspectionDate { get; set; }
        public int? LatestReadinessScore { get; set; }

    }
}

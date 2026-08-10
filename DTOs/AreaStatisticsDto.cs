namespace ShelterApi.DTOs
{
    public class AreaStatisticsDto
    {
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public int shelterCount { get; set; }
        public int totalCapacity { get; set; }
    }
}

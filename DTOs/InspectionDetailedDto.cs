namespace ShelterApi.DTOs
{
    public class InspectionDetailedDto
    {
       public int inspectionId { get; set; }
       public DateTime? InspectionDate { get; set; }
        public int ReadinessScore { get; set; }
        public bool Passed { get; set; }
        public string ShelterName { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
    }
}

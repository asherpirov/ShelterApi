using System.ComponentModel.DataAnnotations;

namespace ShelterApi.DTOs
{
    public class ShelterSortedDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsPublic { get; set; }
        public string ShelterType { get; set; }

    }
}

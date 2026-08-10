using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string BuildingNumber { get; set; } = string.Empty;

        [Range(1, 10000)]
        public int Capacity { get; set; }

        [Required]
        public bool IsAccessible { get; set; } = false;

        [Required]
        public bool IsPublic { get; set; } = false;

        [Required]
        [MaxLength(50)]
        [AllowedValues("PublicBuilding", "School", "Parking", "Residential", "Commercial")]
        public string ShelterType { get; set; } = string.Empty;

        [Required]
        public int AreaId { get; set; }
        public Area Area { get; set; } = null!;
        public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}

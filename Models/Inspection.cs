using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        [Required]
        public DateTime? InspectionDate { get; set; } = DateTime.UtcNow;
       

        [Required]
        public bool Passed { get; set; } = false;

        [Required]
        [Range(0, 100)]
        public int ReadinessScore { get; set; }

        [Required]
        [Range(0,100)]
        public int DefectsCount { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required]
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; } = null!;

    }
}

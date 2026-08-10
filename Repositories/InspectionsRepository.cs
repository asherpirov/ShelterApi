using Microsoft.EntityFrameworkCore;
using ShelterApi.Data;
using ShelterApi.DTOs;

namespace ShelterApi.Repositories
{
    public class InspectionsRepository : IInspectionsRepository
    {
        private readonly ShelterDbContext _context;

        public InspectionsRepository(ShelterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InspectionDetailedDto>> GetAllAsync()
        {
            return await _context.Inspections.Select(i => new InspectionDetailedDto
            {
                inspectionId = i.Id,
                InspectionDate = i.InspectionDate,
                ReadinessScore = i.ReadinessScore,
                Passed = i.Passed,
                ShelterName = i.Shelter.Name,
                City = i.Shelter.Area.City,
                Neighborhood = i.Shelter.Area.Neighborhood
            }).ToListAsync();
        }

        public async Task<IEnumerable<FailedInspectionDto>> GetFailedInspections()
        {

            return await _context.Inspections
                .Where(i => i.Passed == false)
                .Select(i => new FailedInspectionDto
            {
                InspectionId = i.Id,
                InspectionDate = i.InspectionDate,
                ReadinessScore = i.ReadinessScore,
                DefectsCount = i.DefectsCount,
                ShelterName = i.Shelter.Name,
                City = i.Shelter.Area.City,
            }).ToListAsync();
        }

    }
}

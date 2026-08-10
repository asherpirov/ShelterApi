using Microsoft.EntityFrameworkCore;
using ShelterApi.Data;
using ShelterApi.DTOs;
using ShelterApi.Models;

namespace ShelterApi.Repositories
{
    public class AreaRepository : IAreasRepository
    {
        private readonly ShelterDbContext _context;

        public AreaRepository(ShelterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AreaStatisticsDto>> GetAreaStatsAsync()
        {
            return await _context.Areas.Select(a => new AreaStatisticsDto
            {
                City = a.City,
                Neighborhood = a.Neighborhood,
                shelterCount = a.Shelters.Count,
                totalCapacity = a.Shelters.Sum(a => a.Capacity)

            }).ToListAsync();
        }
    }
}

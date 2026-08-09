using Microsoft.EntityFrameworkCore;
using ShelterApi.Data;
using ShelterApi.DTOs;

namespace ShelterApi.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ShelterDbContext _context;

        public ShelterRepository(ShelterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShelterWithAreaDto>> GetAllAsync()
        {
            return await _context.Shelters
                .Select(s => new ShelterWithAreaDto
                {
                    ShelterId = s.Id,
                    ShelterName = s.Name,
                    Capacity = s.Capacity,
                    City = s.Area.City,
                    Neighborhood = s.Area.Neighborhood
                }).ToListAsync();
        }

    }
}

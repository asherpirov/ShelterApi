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

        public async Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
            string? city, int? minCapacity, bool? isAccessible, bool? isPublic)
        {
            var query = _context.Shelters.AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(s => s.Area.City == city);
            }
            if (minCapacity.HasValue)
            {
                query = query.Where(s => s.Capacity <= minCapacity.Value);
            }
            if (isAccessible.HasValue)
            {
                query = query.Where(s => s.IsAccessible == isAccessible.Value);
            }
            if (isPublic.HasValue)
            {
                query = query.Where(s => s.IsPublic == isPublic.Value);
            }
            return await query.Select(s => new ShelterSearchResultDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                City = s.Area.City
                
            }).ToListAsync();

        }
    }
}

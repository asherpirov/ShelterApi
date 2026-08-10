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

        public async Task<IEnumerable<ShelterSortedDto>> SortedAsync(string? sortBy, bool ascending = true)
        {
            var query = _context.Shelters.AsQueryable();
            query = sortBy?.ToLower() switch
            {
                "city" => ascending ? query.OrderBy(s => s.Area.City) :
                query.OrderByDescending(p => p.Area.City),

                "capacity" => ascending ? query.OrderBy(s => s.Capacity) :
                query.OrderByDescending(s => s.Capacity),

                _ => query.OrderBy(s => s.Name)
            };
            return await query.Select(s => new ShelterSortedDto
            {
                Name = s.Name,
                City = s.Area.City,
                Capacity = s.Capacity,
                BuildingNumber = s.BuildingNumber,
                Street = s.Street,
                ShelterType = s.ShelterType,
                IsAccessible = s.IsAccessible,
                IsPublic = s.IsPublic     
            }).ToListAsync();

        }

        public async Task<IEnumerable<ShelterWithInspectionCountDto>> GetShelterWithInspectionCountAsync()
        {
            return await _context.Shelters.Select(s => new ShelterWithInspectionCountDto
            {
                ShelterId = s.Id,
                ShelterName = s.Name,
                InspectionCount = s.Inspections.Count
            }).ToListAsync();
        }

        public async Task<IEnumerable<ShelterTypeAverageDto>> GetAverageScoreByTypeAsync()
        {
            return await _context.Inspections.GroupBy(a => a.Shelter.ShelterType)
                .Select(s => new ShelterTypeAverageDto
            {
                ShelterType = s.Key,
                AverageReadinessScore = s.Average(s => s.ReadinessScore),
                TotalInspections = s.Sum(s => s.Shelter.Inspections.Count())
            }).ToListAsync();
        }

        public async Task<PagedResultDto<ShelterDetailDto>> GetPagination(int page = 1, int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }
            if (pageSize < 5)
            {
                pageSize = 5;
            }
            else if (pageSize > 50)
            {
                pageSize = 50;
            }


            var totalCount = await _context.Shelters.CountAsync();

            var items = await _context.Shelters
               .OrderBy(s => s.Name)
               .Skip((page -1) * pageSize)
               .Take(pageSize)
               .Select(s => new ShelterDetailDto
            {
                Id = s.Id,
                Name = s.Name,
                Capacity = s.Capacity
            }).ToListAsync();

            return new PagedResultDto<ShelterDetailDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page, 
                PageSize = pageSize
            };
        }

    }
}

using ShelterApi.DTOs;
namespace ShelterApi.Repositories
{
    public interface IShelterRepository
    {
        public Task<IEnumerable<ShelterWithAreaDto>> GetAllAsync();

        public Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
            string? city, int? minCapacity, bool? isAccessible, bool? isPublic);

        public Task<IEnumerable<ShelterSortedDto>> SortedAsync(string sortBy = "name", bool ascending = true);

        public Task<IEnumerable<ShelterWithInspectionCountDto>> GetShelterWithInspectionCountAsync();

        public Task<IEnumerable<ShelterTypeAverageDto>> GetAverageScoreByTypeAsync();

        public Task<IEnumerable<PagedResultDto<ShelterWithAreaDto>>>
            GetPagination(int page = 1, int pageSize = 10);
    }

}

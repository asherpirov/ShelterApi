using ShelterApi.DTOs;
namespace ShelterApi.Repositories
{
    public interface IShelterRepository
    {
        public Task<IEnumerable<ShelterWithAreaDto>> GetAllAsync();

        public Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(
            string? city, int? minCapacity, bool? isAccessible, bool? isPublic);
    }
}

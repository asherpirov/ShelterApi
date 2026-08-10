using ShelterApi.DTOs;

namespace ShelterApi.Repositories
{
    public interface IAreasRepository
    {
        public Task<IEnumerable<AreaStatisticsDto>> GetAreaStatsAsync();
    }
}

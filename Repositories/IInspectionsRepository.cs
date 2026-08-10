using ShelterApi.DTOs;

namespace ShelterApi.Repositories
{
    public interface IInspectionsRepository
    {
        public Task<IEnumerable<InspectionDetailedDto>> GetAllAsync();
        public Task<IEnumerable<FailedInspectionDto>> GetFailedInspections();
    }
}

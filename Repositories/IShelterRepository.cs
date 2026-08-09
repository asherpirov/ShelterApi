using ShelterApi.DTOs;
namespace ShelterApi.Repositories
{
    public interface IShelterRepository
    {
        public Task<IEnumerable<ShelterWithAreaDto>> GetAllAsync();
    }
}

using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Repositories;

namespace ShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheltersController : ControllerBase
    {
        private readonly IShelterRepository _repository;

        public SheltersController(IShelterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("with-area")]
        public async Task<ActionResult<IEnumerable<ShelterWithAreaDto>>> GetShelterWithAreaAsync()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ShelterSearchResultDto>>> SearchAsync(
            [FromQuery] string? city,
            [FromQuery] int? minCapacity,
            [FromQuery] bool? isAccessible,
            [FromQuery] bool? isPublic)
        {
            return Ok(await _repository.SearchAsync(city, minCapacity, isAccessible, isPublic));
        }

        [HttpGet("sorted")]
        public async Task<ActionResult<IEnumerable<ShelterSortedDto>>> SortedAsync(string sortBy = "name", bool ascending = true)
        {
            return Ok(await _repository.SortedAsync(sortBy, ascending));
        }

    }
}

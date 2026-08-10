using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Repositories;

namespace ShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IAreasRepository _repository;

        public AreasController(IAreasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<IEnumerable<AreaStatisticsDto>>> GetAreaStats()
        {
            return Ok(await _repository.GetAreaStatsAsync());
        }

    }
}

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
    }
}

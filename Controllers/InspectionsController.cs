using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Repositories;

namespace ShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionsRepository _repository;

        public InspectionsController(IInspectionsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> GetAllAsync()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("failed")]
        public async Task<ActionResult<IEnumerable<FailedInspectionDto>>> GetFailedInspections()
        {
            return Ok(await _repository.GetFailedInspections());        }


    }
}

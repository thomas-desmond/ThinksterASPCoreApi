using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksterASPCoreApi.DatabaseEntities;
using ThinksterASPCoreApi.Repository;

namespace ThinksterASPCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly ISpaceRepository _spaceRepository;

        public PlanetsController(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Planet> result = await _spaceRepository.GetAllPlanetsAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    "Could not reach the database");
            }

        }
    }
}

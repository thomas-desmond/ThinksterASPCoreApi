using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public async Task<IActionResult> Get(bool returnMoons = false)
        {
            try
            {
                List<Planet> result = await _spaceRepository.GetAllPlanetsAsync(returnMoons);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool returnMoons = false)
        {
            try
            {
                Planet result = await _spaceRepository.GetPlanetAsync(id, returnMoons);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Planet planet)
        {
            try
            {
                _spaceRepository.AddPlanet(planet);
                bool result = await _spaceRepository.SaveChangesAsync();
                if (result)
                {
                    return Created($"/api/planets/{planet.Id}", planet);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }

            return BadRequest();
        }
    }
}

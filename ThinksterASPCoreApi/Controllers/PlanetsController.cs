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
        private readonly LinkGenerator _linkGenerator;

        public PlanetsController(ISpaceRepository spaceRepository, LinkGenerator linkGenerator)
        {
            _spaceRepository = spaceRepository;
            _linkGenerator = linkGenerator;
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
                var location = _linkGenerator.GetPathByAction("Get", "Planets", new { id = planet.Id });

                _spaceRepository.AddPlanet(planet);
                bool result = await _spaceRepository.SaveChangesAsync();
                if (result)
                {
                    return Created($"/api/planets/{location}", planet);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
        }
    }
}

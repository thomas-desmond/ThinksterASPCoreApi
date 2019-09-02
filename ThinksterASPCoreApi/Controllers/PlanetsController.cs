using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is missing data");
                }

                _spaceRepository.AddPlanet(planet);
                bool result = await _spaceRepository.SaveChangesAsync();
                if (result)
                {
                    return Created($"api/planets/{planet.Id}", planet);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Planet newPlanetData)
        {
            try
            {
                if (id != newPlanetData.Id)
                {
                    return BadRequest();
                }

                var existingPlanet = await _spaceRepository.GetPlanetAsync(id);
                if (existingPlanet == null)
                {
                    return NotFound($"No planet exists with the id {id}");
                }

                existingPlanet.Mass = newPlanetData.Mass;
                existingPlanet.Name = newPlanetData.Name;

                await _spaceRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var planetToDelete = await _spaceRepository.GetPlanetAsync(id);
                if (planetToDelete == null)
                {
                    return NotFound($"No planet exists with the id {id}");
                }

                _spaceRepository.DeletePlanet(planetToDelete);

                bool result = await _spaceRepository.SaveChangesAsync();
                if (result)
                {
                    return Ok();
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

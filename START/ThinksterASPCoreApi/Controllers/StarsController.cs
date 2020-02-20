using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinksterASPCoreApi.DatabaseEntities;
using ThinksterASPCoreApi.Repository;

namespace ThinksterASPCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarsController : ControllerBase
    {
        private readonly ISpaceRepository _spaceRepository;

        public StarsController(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        // Exercise 1: The GET method below is currently returning null.
        // Modify the GET method to return a HTTP 200 response
        // code if the request is succesful and a HTTP 500 error 
        // if the call is unsuccesful
        [HttpGet]
        public async Task<IActionResult> Get(bool returnFact = false)
        {
                return null;
        }

        // Exercise 2: The GET method below is currently returning null.
        // Modify the GET to return a HTTP 404 response code
        // if the given ID does not match anything in our database. Also
        // allow the user to use the "returnFact" query string as part of 
        // the URL request 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool returnFact = false)
        {
            try
            {
                Star result = null;

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Could not reach the database");
            }
        }

        // Exercise 3: The POST & PUT methods below are currently implemented and working.
        // But they contain no error handling. Improve the two methods so that bad and invalid 
        // requests are handled properly and meaningful status codes are returned to the user.
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Star star)
        {
            _spaceRepository.AddStar(star);
            bool result = await _spaceRepository.SaveChangesAsync();
            return Created($"api/stars/{star.Id}", star);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Star newStarData)
        {
            var existingStar = await _spaceRepository.GetStarAsync(id, true);

            existingStar.AgeInMillions = newStarData.AgeInMillions;
            existingStar.Name = newStarData.Name;
            existingStar.Fact = newStarData.Fact;

            await _spaceRepository.SaveChangesAsync();

            return NoContent();
        }

        // Exercise 4: The DELETE method below is currently working. However, 
        // none of the return statements include any text. Look at what would 
        // cause each return statement to be executed. Write a meaningful message
        // that could be returned with each return to help your user. 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var starToDelete = await _spaceRepository.GetStarAsync(id);
                if (starToDelete == null)
                {
                    return NotFound();
                }

                _spaceRepository.DeleteStar(starToDelete);

                bool result = await _spaceRepository.SaveChangesAsync();
                if (result)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
    }
}
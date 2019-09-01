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
            try
            {
                List<Star> result = await _spaceRepository.GetAllStarsAsync(returnFact);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                                    "Could not reach the database");
            }
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
                Star result = await _spaceRepository.GetStarAsync(id, returnFact);

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
    }
}

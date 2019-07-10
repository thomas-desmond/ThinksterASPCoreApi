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

        // The GET method below is currently returning null.
        // Modify the GET method to return a HTTP 200 response
        // code if the request is succesful and a HTTP 500 error 
        // if the call is unsuccesful
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Star> result = await _spaceRepository.GetAllSunsAsync();
            return null;
        }
    }
}

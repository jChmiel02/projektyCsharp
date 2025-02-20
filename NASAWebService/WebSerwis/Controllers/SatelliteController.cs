using Microsoft.AspNetCore.Mvc;
using NASAWebService.Base;
using NASAWebService.Services;

namespace NASAWebService.Controllers
{
    [ApiController]
    [Route("api/satellite")]

    public class SatelliteController : ControllerBase
    {
        private readonly ISatelliteService _satelliteService;

        public SatelliteController(ISatelliteService satelliteService)
        {
            _satelliteService = satelliteService;
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetSatelliteNames()
        {
            var names = await _satelliteService.GetSatelliteNamesAsync();
            return Ok(names);
        }

        [HttpGet("{satelliteName}")] 
        public async Task<IActionResult> GetSatelliteDetails(string satelliteName)
        {
            var details = await _satelliteService.GetSatelliteDetailsAsync(satelliteName); 
            if (details == null)
            {
                return NotFound("Satellite not found.");
            }
            return Ok(details);
        }

        private bool ValidateClientToken()
        {
            if (Request.Headers.TryGetValue("Client-Token", out var token))
            {
                return token == "token"; 
            }
            return false;
        }

        [HttpGet("validate")]
        public IActionResult CheckToken()
        {
            if (ValidateClientToken())
            {
                return Ok("Token is valid.");
            }
            return Unauthorized("Invalid or missing Client-Token.");
        }
    }

}

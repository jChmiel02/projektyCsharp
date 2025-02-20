using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NASAWebService.Base;
using WebServiceStart.Web.Models;
using NASAWebService.Models;

namespace NASAWebService.Controllers
{
    [ApiController]
    [Route("api/osdr")]
    public class OsdrController : ControllerBase
    {
        private readonly IOsdrService _osdrService;
        private readonly IMapper _mapper;

        public OsdrController(IOsdrService osdrService, IMapper mapper)
        {
            _osdrService = osdrService;
            _mapper = mapper;
        }

        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            var result = await _osdrService.GetVehiclesAsync();
            var vehicles = _mapper.Map<List<VehicleDto>>(result.data);
            return Ok(vehicles);
        }

        [HttpGet("vehicle")]
        public async Task<IActionResult> GetVehicle([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest("URL cannot be empty.");

            var result = await _osdrService.GetVehicleAsync(url);
            var missionDetails = _mapper.Map<MissionDetailDto>(result);
            return Ok(missionDetails);
        }

        [HttpGet("mission")]
        public async Task<IActionResult> GetMissionDetails([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest("URL cannot be empty.");

            var result = await _osdrService.GetMissionDetailsAsync(url);
            var missionDetails = _mapper.Map<MissionDetailDto>(result);
            return Ok(missionDetails);
        }


    }
}
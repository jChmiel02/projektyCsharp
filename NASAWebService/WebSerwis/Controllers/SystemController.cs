using Microsoft.AspNetCore.Mvc;
using NASAWebService.Models;
using AutoMapper;
using System.Net.Http;
using System.Threading.Tasks;
using NASAWebService.Models.Dto;

namespace NASAWebService.Controllers
{
    [ApiController]
    [Route("api/system")]
    public class SystemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public SystemController(IConfiguration configuration, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatus()
        {
            bool nasaApiStatus;
            string status;
            try
            {
                string baseUrl = _configuration["NASA:ApiUrl"];
                string apiKey = _configuration["NASA:ApiKey"];

                var response = await _httpClient.GetAsync($"{baseUrl}?api_key={apiKey}");
                nasaApiStatus = response.IsSuccessStatusCode;
            }
            catch
            {
                nasaApiStatus = false;
            }
            status = (nasaApiStatus) ? "Running" : "Unavailable";
            return Ok(new
            {
                status,
                nasaApiStatus
            });
        }

        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            var systemInfo = _configuration.GetSection("SystemInfo").Get<SystemInfoOptions>();
            var systemInfoDto = _mapper.Map<SystemInfoDto>(systemInfo);
            return Ok(systemInfoDto);
        }
    }
}

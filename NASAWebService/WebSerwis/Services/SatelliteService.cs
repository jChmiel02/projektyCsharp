using AutoMapper;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NASAWebService.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NASAWebService.Models.Dto;

namespace NASAWebService.Services
{
    public class SatelliteService : ISatelliteService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly string _apiUrl;

        public SatelliteService(HttpClient httpClient, IMapper mapper, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _apiUrl = configuration["SatelliteService:ApiUrl"];
        }

        public async Task<List<string>> GetSatelliteNamesAsync()
        {
            var root = await _httpClient.GetFromJsonAsync<Root>(_apiUrl);
            var satelliteListDto = _mapper.Map<SatelliteListDto>(root);
            return satelliteListDto.Names;
        }

        public async Task<SatelliteDto> GetSatelliteDetailsAsync(string satelliteName)
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var root = JsonConvert.DeserializeObject<Root>(response);
            var member = root?.Member?.FirstOrDefault(m => m.Name.Equals(satelliteName, StringComparison.OrdinalIgnoreCase));
            return member != null ? _mapper.Map<SatelliteDto>(member) : null;
        }


    }
}

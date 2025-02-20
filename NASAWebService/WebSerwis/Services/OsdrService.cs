using NASAWebService.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NASAWebService.Base;
using Microsoft.Extensions.Configuration;
using WebServiceStart.Web.Models;
using AutoMapper;

namespace NASAWebService.Services
{
    public class OsdrService : IOsdrService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        private readonly IMapper _mapper;

        public OsdrService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["OsdrService:ApiUrl"];
            _mapper = mapper;
        }

        public async Task<VehiclesRoot> GetVehiclesAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<VehiclesRoot>();
        }

        public async Task<MissionDetailsRoot> GetVehicleAsync(string vehicleUrl)
        {
            var response = await _httpClient.GetAsync(vehicleUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MissionDetailsRoot>();
        }

        public async Task<MissionDetailsRoot> GetMissionDetailsAsync(string missionUrl)
        {
            var response = await _httpClient.GetAsync(missionUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MissionDetailsRoot>();
        }

    }
}

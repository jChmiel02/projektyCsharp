using AutoMapper;
using Microsoft.Extensions.Options;
using System.Text.Json;
using NASAWebService.Base;
using NASAWebService.Models;
using NASAWebService;
using NASAWebService.Models.Dto;

public class ApodService : IApodService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl;
    private readonly IMapper _mapper;

    public ApodService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _httpClient = httpClient;
        _apiKey = configuration["NASA:ApiKey"];
        _apiUrl = configuration["NASA:ApiUrl"];
        _mapper = mapper;
    }

    public async Task<ApodDto> GetApodAsync()
    {
        var url = $"{_apiUrl}?api_key={_apiKey}";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();

        var apod = JsonSerializer.Deserialize<APOD>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return _mapper.Map<ApodDto>(apod);
    }
}



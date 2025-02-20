using NASAWebService.Models.Dto;

namespace NASAWebService.Base
{
    public interface ISatelliteService
    {
        Task<List<string>> GetSatelliteNamesAsync();
        Task<SatelliteDto> GetSatelliteDetailsAsync(string satelliteName);
    }
}

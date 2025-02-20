using NASAWebService.Models;

namespace NASAWebService.Base
{
    public interface IOsdrService
    {
        Task<VehiclesRoot> GetVehiclesAsync();
        Task<MissionDetailsRoot> GetVehicleAsync(string vehicleUrl);
        Task<MissionDetailsRoot> GetMissionDetailsAsync(string missionUrl);
    }
}
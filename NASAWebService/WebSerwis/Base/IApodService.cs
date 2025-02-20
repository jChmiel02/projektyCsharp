using NASAWebService.Models.Dto;

namespace NASAWebService.Base
{
    public interface IApodService
    {
        Task<ApodDto> GetApodAsync();
    }

}

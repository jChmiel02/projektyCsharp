using AutoMapper;
using NASAWebService.Models;
using NASAWebService.Models.Dto;

namespace NASAWebService.AutoMapper
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<SystemInfoOptions, SystemInfoDto>()
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.Date));
        }
    }
}

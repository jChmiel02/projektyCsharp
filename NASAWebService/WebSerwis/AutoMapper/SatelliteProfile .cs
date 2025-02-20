using AutoMapper;
using NASAWebService.Models.Dto;

namespace NASAWebService.AutoMapper
{
    public class SatelliteProfile : Profile
    {
        public SatelliteProfile()
        {
            CreateMap<Satelite, SatelliteDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.SatelliteId, opt => opt.MapFrom(src => src.SatelliteId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.Line1))
                .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.Line2));

            CreateMap<Root, SatelliteListDto>()
                .ForMember(dest => dest.Names, opt => opt.MapFrom(src => src.Member.Select(m => m.Name).ToList()));
        }
    }
}

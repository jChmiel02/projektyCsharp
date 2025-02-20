using AutoMapper;
using NASAWebService.Models;
using NASAWebService.Models.Dto;

namespace WebServiceStart.Web.AutoMapper
{
    public class ApodProfile : Profile
    {
        public ApodProfile()
        {
            CreateMap<APOD, ApodDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.explanation))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.url));
        }
    }
}


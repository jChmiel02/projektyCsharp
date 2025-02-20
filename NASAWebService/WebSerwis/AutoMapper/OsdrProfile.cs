using AutoMapper;
using NASAWebService.Models;
using WebServiceStart.Web.Models;

namespace WebServiceStart.Web.AutoMapper
{
    public class OsdrProfile : Profile
    {
        public OsdrProfile()
        {
            CreateMap<Datum, VehicleDto>()
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.vehicle));

            CreateMap<NASAWebService.Models.Vehicle, FileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id));
            
            CreateMap<VersionInfo, VersionInfoDto>()
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.version));

            CreateMap<Mission, MissionDto>()
                .ForMember(dest => dest.Mission, opt => opt.MapFrom(src => src.mission));

            CreateMap<People, MissionParticipantDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.person.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.person.lastName))
                .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.institution))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.person.phone));

            CreateMap<MissionDetailsRoot, MissionDetailDto>()
                .ForMember(dest => dest.Missions, opt => opt.MapFrom(src => src.parents.mission))
                .ForMember(dest => dest.Participants, opt => opt.MapFrom(src => src.people));
        }
    }

}
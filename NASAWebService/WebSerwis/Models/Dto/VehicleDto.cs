using NASAWebService.Models;

namespace WebServiceStart.Web.Models
{
    public class VehicleDto
    {
        public string Vehicle { get; set; }
    }
    public class FileDto
    {
        public string Id { get; set; }
        public string FullPath { get; set; }
        public string Subcategory { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

    public class VersionInfoDto
    {
        public string DocumentKey { get; set; }
        public int Version { get; set; }
        public bool Deleted { get; set; }
    }

    public class MissionDto
    {
        public string Mission { get; set; }
    }
    public class MissionParticipantDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Institution { get; set; }
        public string Phone { get; set; }
    }

    public class MissionDetailDto
    {
        public string Mission { get; set; }
        public string Id { get; set; }
        public string Identifier { get; set; }
        public List<FileDto> Files { get; set; }
        public VersionInfoDto VersionInfo { get; set; }
        public List<MissionDto> Missions { get; set; }
        public List<MissionParticipantDto> Participants { get; set; }
    }
    namespace WebServiceStart.Web.Models
    {
        public class MissionParticipantDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Institution { get; set; }
            public string Phone { get; set; }
        }

        public class MissionDetailDto
        {
            public string Mission { get; set; }
            public string Id { get; set; }
            public string Identifier { get; set; }
            public List<FileDto> Files { get; set; }
            public VersionInfoDto VersionInfo { get; set; }
            public List<MissionDto> Missions { get; set; }
            public List<MissionParticipantDto> Participants { get; set; }
        }
    }


}
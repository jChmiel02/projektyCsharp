namespace NASAWebService.Models
{
    public class Datum
    {
        public string vehicle { get; set; }
    }

    public class VehiclesRoot
    {
        public List<Datum> data { get; set; }
    }
    public class Vehicle
    {
        public string id { get; set; }
        public string fullPath { get; set; }
        public string subcategory { get; set; }
        public string subdirectory { get; set; }
        public string collectionSite { get; set; }
        public int fileSize { get; set; }
        public string description { get; set; }
        public string collectionDays { get; set; }
        public string category { get; set; }
    }

    public class Mission
    {
        public string mission { get; set; }
    }

    public class Parents
    {
        public List<Mission> mission { get; set; }
    }

    public class MissionDetailsRoot
    {
        public string id { get; set; }
        public string identifier { get; set; }
        public string identifierLowercase { get; set; }
        public string esID { get; set; }
        public List<Vehicle> files { get; set; }
        public VersionInfo versionInfo { get; set; }
        public Parents parents { get; set; }
        public List<People> people { get; set; } 
    }

    public class People
    {
        public string institution { get; set; }
        public List<string> roles { get; set; }
        public Person person { get; set; }
    }

    public class Person
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public VersionInfo versionInfo { get; set; }
    }


    public class VersionInfo
    {
        public string documentKey { get; set; }
        public int version { get; set; }
        public bool deleted { get; set; }
    }
} 
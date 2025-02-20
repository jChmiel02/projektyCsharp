using Newtonsoft.Json;

namespace NASAWebService.Models.Dto
{
    public class SatelliteDto
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public int SatelliteId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }

    public class SatelliteListDto
    {
        public List<string> Names { get; set; }
    }
}

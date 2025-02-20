using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Satelite
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

public class Parameters
{
    public string Search { get; set; }
    public string Sort { get; set; }

    [JsonProperty("sort-dir")]
    public string SortDir { get; set; }
    public int Page { get; set; }

    [JsonProperty("page-size")]
    public int PageSize { get; set; }
}

public class View
{
    [JsonProperty("@id")]
    public string Id { get; set; }

    [JsonProperty("@type")]
    public string Type { get; set; }
    public string First { get; set; }
    public string Next { get; set; }
    public string Last { get; set; }
}

public class Root
{
    [JsonProperty("@context")]
    public string Context { get; set; }

    [JsonProperty("@id")]
    public string Id { get; set; }

    [JsonProperty("@type")]
    public string Type { get; set; }

    public int TotalItems { get; set; }
    public List<Satelite> Member { get; set; }
    public Parameters Parameters { get; set; }
    public View View { get; set; }
}

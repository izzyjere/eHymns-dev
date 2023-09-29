namespace EHymns.Models;


public class Hymn
{
    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("titleWithHymnNumber")]
    public string TitleWithHymnNumber { get; set; }

    [JsonProperty("chorus")]
    public string Chorus { get; set; }

    [JsonProperty("verses")]
    public List<string> Verses { get; set; }

    [JsonProperty("sound")]
    public string Sound { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }
}
using Newtonsoft.Json;

public class ConfigJson{
    [JsonProperty("token")]
    public string? Token {get; private set; }
}
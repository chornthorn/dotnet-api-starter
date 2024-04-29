using Newtonsoft.Json;

namespace DotNetApp.Core;

public class Response<T>
{
    [JsonProperty("statusCode")] public int StatusCode { get; set; }

    [JsonProperty("message")] public string Message { get; set; } = string.Empty;

    [JsonProperty("detailed")] public string Detailed { get; set; } = string.Empty;

    [JsonProperty("data")] public T Data { get; set; } = default!;
}
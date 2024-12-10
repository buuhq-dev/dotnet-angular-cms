using System.Text.Json.Serialization;

namespace Blog.WebMvc.Models;

public class UploadResponse
{
    [JsonPropertyName("path")]
    public string Path { get; set; }
}
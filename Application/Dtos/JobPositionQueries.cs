using System.Text.Json.Serialization;

namespace Application.Dtos;

public class JobPositionQueries {
   [JsonPropertyName("name")] 
   public string? Name { get; init; } = "";
}
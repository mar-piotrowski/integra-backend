using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Dtos;

public class HolidayLimitsQueries {
    [FromQuery]
    [JsonPropertyName("userId")]
    public int UserId { get; set; } = -1;
}
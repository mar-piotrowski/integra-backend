using Domain.Enums;

namespace Application.Dtos;

public record ScheduleDayDto(int SchemaId, Day Day, DateTimeOffset StartDate, DateTimeOffset EndDate);
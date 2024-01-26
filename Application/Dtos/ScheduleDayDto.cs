using Domain.Enums;

namespace Application.Dtos;

public record ScheduleDayDto(Day Day, DateTimeOffset Start, DateTimeOffset End);
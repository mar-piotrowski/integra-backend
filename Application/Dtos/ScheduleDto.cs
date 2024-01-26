namespace Application.Dtos;

public record ScheduleDto(
    int Id,
    string Name,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    decimal TotalHours,
    List<ScheduleDayDto> Days
);
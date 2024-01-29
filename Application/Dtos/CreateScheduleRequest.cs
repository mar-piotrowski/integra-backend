namespace Application.Dtos;

public record CreateScheduleRequest(
    string Name,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    List<ScheduleDayDto> Days
);
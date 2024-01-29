namespace Application.Dtos;

public record UpdateScheduleRequest(
    string Name,
    DateTime StartDate,
    DateTime? EndDate,
    List<ScheduleDayDto> Days
);
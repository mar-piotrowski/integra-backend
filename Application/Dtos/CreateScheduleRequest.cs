namespace Application.Dtos;

public record CreateScheduleRequest(
    string Name,
    DateTime StartDate,
    DateTime? EndDate,
    List<ScheduleDayDto> Days
);
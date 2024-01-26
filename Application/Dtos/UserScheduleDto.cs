namespace Application.Dtos;

public record UserScheduleDto(
    int Year,
    int Month,
    decimal TotalHours,
    UserShortDto User,
    List<ScheduleDayDto> Days
);
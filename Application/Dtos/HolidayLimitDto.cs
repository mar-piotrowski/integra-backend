namespace Application.Dtos;

public record HolidayLimitDto(
    int Id,
    DateTime Current,
    DateTime StartDate,
    DateTime EndDate,
    int AvailableDays,
    int UsedDays,
    int MergedDays,
    string Description
);
namespace Application.Dtos;

public record CreateHolidayLimitRequest(
    int UserId, 
    DateTime Current,
    DateTime StartDate,
    DateTime EndDate,
    string Description
);
    
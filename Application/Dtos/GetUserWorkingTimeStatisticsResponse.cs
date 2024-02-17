namespace Application.Dtos;

public record GetUserWorkingTimeStatisticsResponse(
    int MonthWorkingHours,
    int TotalUserWorkedSeconds,
    int OverUserWorkedSeconds
);
namespace Application.Dtos;

public record CreateJobHistoryRequest(
    int UserId,
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime EndDate
);
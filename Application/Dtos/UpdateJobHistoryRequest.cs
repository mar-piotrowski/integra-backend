namespace Application.Dtos;

public record UpdateJobHistoryRequest(
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime EndDate
);
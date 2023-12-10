namespace Application.Dtos;

public record JobHistoryDto(
    int Id,
    int UserId,
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime EndDate
);
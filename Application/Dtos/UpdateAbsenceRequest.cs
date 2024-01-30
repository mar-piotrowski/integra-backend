namespace Application.Dtos;

public record UpdateAbsenceRequest (
    DateTime StartDate,
    DateTime EndDate,
    string? DiseaseCode,
    string? Series,
    string? Number,
    string? Description,
    int UserId
);
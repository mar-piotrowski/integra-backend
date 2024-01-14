using Domain.Enums;

namespace Application.Dtos;

public record CreateSchoolHistoryRequest(
    int UserId,
    string SchoolName,
    SchoolDegree Degree,
    string? Specialization,
    string? Title,
    DateTime StartDate,
    DateTime EndDate
);
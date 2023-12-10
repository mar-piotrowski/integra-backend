using Domain.Enums;

namespace Application.Dtos;

public record SchoolHistoryDto(
    int Id,
    string SchoolName,
    SchoolDegree Degree,
    string Specialization,
    string Title,
    DateTime StartDate,
    DateTime EndDate
);
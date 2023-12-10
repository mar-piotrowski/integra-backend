using Domain.Enums;

namespace Application.Dtos;

public record UpdateSchoolHistoryRequest(
    string SchoolName,
    SchoolDegree Degree,
    string Specialization,
    string Title,
    DateTime StartDate,
    DateTime EndDate
); 
using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class SchoolHistoryMapper {
    public static SchoolHistoryDto MapToDto(this SchoolHistory schoolHistory) => new SchoolHistoryDto(
        schoolHistory.Id.Value,
        schoolHistory.SchoolName,
        schoolHistory.Degree,
        schoolHistory.Specialization,
        schoolHistory.Title,
        schoolHistory.StartDate,
        schoolHistory.EndDate
    );

    public static List<SchoolHistoryDto> MapToDtos(this IEnumerable<SchoolHistory> schoolHistories) =>
        schoolHistories.Select(schoolHistory => schoolHistory.MapToDto()).ToList();
}
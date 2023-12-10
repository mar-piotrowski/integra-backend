using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class JobHistoryMapper {
    public static JobHistoryDto MapToDto(this JobHistory jobHistory) => new JobHistoryDto(
        jobHistory.Id.Value,
        jobHistory.UserId.Value,
        jobHistory.CompanyName,
        jobHistory.Position,
        jobHistory.StartDate,
        jobHistory.EndDate
    );

    public static IEnumerable<JobHistoryDto> MapToDtos(this IEnumerable<JobHistory> jobHistories) =>
        jobHistories.Select(jobHistory => jobHistory.MapToDto());
}
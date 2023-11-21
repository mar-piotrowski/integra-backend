using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class JobPositionMapper {
    public static IEnumerable<JobPositionDto> MapToDtos(this IEnumerable<JobPosition> jobPositions) =>
        jobPositions.Select(jobPosition => new JobPositionDto(jobPosition.Title));
}
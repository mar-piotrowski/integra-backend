using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class JobPositionMapper {
    public JobPositionDto MapToDto(JobPosition jobPosition) =>
        new JobPositionDto(jobPosition.Id.Value, jobPosition.Title);
    
    public IEnumerable<JobPositionDto> MapToDtos(IEnumerable<JobPosition> jobPositions) =>
        jobPositions.Select(MapToDto);
}
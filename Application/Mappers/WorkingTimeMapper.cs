using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class WorkingTimeMapper {
    private readonly UserMapper _userMapper;

    public WorkingTimeMapper(UserMapper userMapper) {
        _userMapper = userMapper;
    }

    public WorkingTimeDto MapToDto(WorkingTime workingTime) =>
        new WorkingTimeDto(
            workingTime.Id.Value,
            workingTime.StartDate,
            workingTime.EndDate,
            workingTime.TotalSeconds,
            workingTime.Status,
            _userMapper.MapToShortDto(workingTime.User)
        );

    public List<WorkingTimeDto> MapToDtos(IEnumerable<WorkingTime> workingTimes) =>
        workingTimes.Select(MapToDto).ToList();
}
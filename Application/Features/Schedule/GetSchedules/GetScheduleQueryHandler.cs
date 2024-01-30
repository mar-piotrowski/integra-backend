using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Schedule.GetSchedules;

public class GetScheduleQueryHandler : IQueryHandler<GetScheduleQuery, ScheduleDto> {
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ScheduleMapper _scheduleMapper;

    public GetScheduleQueryHandler(IScheduleRepository scheduleRepository, ScheduleMapper scheduleMapper) {
        _scheduleRepository = scheduleRepository;
        _scheduleMapper = scheduleMapper;
    }

    public async Task<Result<ScheduleDto>> Handle(GetScheduleQuery request, CancellationToken cancellationToken) {
        var schedule = _scheduleRepository.FindById(request.Id);
        return schedule is null
            ? Result.Failure<ScheduleDto>(ScheduleErrors.NotFound)
            : Result.Success(_scheduleMapper.MapToDto(schedule));
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Schedule.GetSchedule;

public class GetSchedulesQueryHandler : IQueryHandler<GetSchedulesQuery, SchedulesResponse> {
    private readonly IScheduleRepository _scheduleRepository;
    private readonly ScheduleMapper _scheduleMapper;

    public GetSchedulesQueryHandler(IScheduleRepository scheduleRepository, ScheduleMapper scheduleMapper) {
        _scheduleRepository = scheduleRepository;
        _scheduleMapper = scheduleMapper;
    }

    public async Task<Result<SchedulesResponse>> Handle(
        GetSchedulesQuery request,
        CancellationToken cancellationToken
    ) {
        var schedules = _scheduleRepository.GetAll().ToList();
        return !schedules.Any()
            ? Result.Failure<SchedulesResponse>(ScheduleErrors.NotFoundAny)
            : Result.Success(new SchedulesResponse(_scheduleMapper.MapToDtos(schedules)));
    }
}
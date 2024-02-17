using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.WorkingTime.GetAll;

public class GetWorkingTimesQueryHandler : IQueryHandler<GetWorkingTimesQuery, WorkingTimesResponse> {
    private readonly IWorkingTimeRepository _workingTimeRepository;
    private readonly WorkingTimeMapper _workingTimeMapper;

    public GetWorkingTimesQueryHandler(
        IWorkingTimeRepository workingTimeRepository,
        WorkingTimeMapper workingTimeMapper
    ) {
        _workingTimeRepository = workingTimeRepository;
        _workingTimeMapper = workingTimeMapper;
    }

    public async Task<Result<WorkingTimesResponse>> Handle(
        GetWorkingTimesQuery request,
        CancellationToken cancellationToken
    ) {
        var workingTimes = _workingTimeRepository.FindAll(request.UserId).ToList();
        if (!workingTimes.Any())
            return Result.Failure<WorkingTimesResponse>(WorkingTimeErrors.NotFoundMany);
        return Result.Success<WorkingTimesResponse>(
            new WorkingTimesResponse(_workingTimeMapper.MapToDtos(workingTimes))
        );
    }
}
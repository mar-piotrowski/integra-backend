using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobPosition.GetJobPositions;

public class GetJobPositionsQueryHandler : IQueryHandler<GetJobPositionsQuery, JobPositionsResponse> {
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly JobPositionMapper _jobPositionMapper;

    public GetJobPositionsQueryHandler(
        IJobPositionRepository jobPositionRepository,
        JobPositionMapper jobPositionMapper
    ) {
        _jobPositionRepository = jobPositionRepository;
        _jobPositionMapper = jobPositionMapper;
    }

    public async Task<Result<JobPositionsResponse>> Handle(
        GetJobPositionsQuery request,
        CancellationToken cancellationToken
    ) {
        var jobPositions = _jobPositionRepository.FindAll().ToList();
        if (!jobPositions.Any())
            return Result.Failure<JobPositionsResponse>(JobPositionErrors.NotFoundAny);
        return Result.Success(new JobPositionsResponse(_jobPositionMapper.MapToDtos(jobPositions).ToList()));
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.JobPosition.Query;

public class GetJobPositionsQueryHandler : IQueryHandler<GetJobPositionsQuery, JobPositionsResponse> {
    private readonly IJobPositionRepository _jobPositionRepository;

    public GetJobPositionsQueryHandler(IJobPositionRepository jobPositionRepository) {
        _jobPositionRepository = jobPositionRepository;
    }

    public async Task<Result<JobPositionsResponse>> Handle(
        GetJobPositionsQuery request,
        CancellationToken cancellationToken
    ) {
        var jobPositions = _jobPositionRepository.GetAll();
        if (!jobPositions.Any())
            return Result.Failure<JobPositionsResponse>(JobPositionErrors.NotFoundAny);
        return Result.Success(new JobPositionsResponse(jobPositions.MapToDtos().ToList()));
    }
}
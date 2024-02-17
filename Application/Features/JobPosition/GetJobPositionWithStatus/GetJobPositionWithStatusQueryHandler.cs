using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobPosition.GetJobPositionWithStatus;

public class GetJobPositionWithStatusQueryHandler
    : IQueryHandler<GetJobPositionWithStatusQuery, JobPositionWithStatsResponse> {
    private readonly IContractRepository _contractRepository;
    private readonly IJobPositionRepository _jobPositionRepository;

    public GetJobPositionWithStatusQueryHandler(
        IContractRepository contractRepository,
        IJobPositionRepository jobPositionRepository
    ) {
        _contractRepository = contractRepository;
        _jobPositionRepository = jobPositionRepository;
    }

    public async Task<Result<JobPositionWithStatsResponse>> Handle(
        GetJobPositionWithStatusQuery request,
        CancellationToken cancellationToken
    ) {
        var stats = new List<JobPositionStats>();
        var jobPosition = _jobPositionRepository.FindAll().ToList();
        if (!jobPosition.Any())
            return Result.Failure<JobPositionWithStatsResponse>(JobPositionErrors.NotFoundAny);
        return Result.Success(new JobPositionWithStatsResponse(stats));
    }
}
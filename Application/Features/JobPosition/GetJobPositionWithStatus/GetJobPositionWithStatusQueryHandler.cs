using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobPosition.GetJobPositionWithStatus;

public class GetJobPositionWithStatusQueryHandler
    : IQueryHandler<GetJobPositionWithStatusQuery, JobPositionWithStatsResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IJobPositionRepository _jobPositionRepository;

    public GetJobPositionWithStatusQueryHandler(
        IUserRepository userRepository,
        IJobPositionRepository jobPositionRepository
    ) {
        _userRepository = userRepository;
        _jobPositionRepository = jobPositionRepository;
    }

    public async Task<Result<JobPositionWithStatsResponse>> Handle(
        GetJobPositionWithStatusQuery request,
        CancellationToken cancellationToken
    ) {
        var stats = new List<JobPositionStats>();
        var jobPosition = _jobPositionRepository.GetAll().ToList();
        if (!jobPosition.Any())
            return Result.Failure<JobPositionWithStatsResponse>(JobPositionErrors.NotFoundAny);
        foreach (var position in jobPosition) {
            var totalUsers = CalculateTotalUsers(position.Title);
           stats.Add(new JobPositionStats(position.Id.Value, position.Title, totalUsers, 0)); 
        }

        return Result.Success(new JobPositionWithStatsResponse(stats));
    }

    private decimal CalculateAvgSalary(string jobPosition) {
        return 0;
    }

    private int CalculateTotalUsers(string jobPosition) {
        var users = _userRepository.GetAllWithPosition(jobPosition).ToList();
        return !users.Any() ? 0 : users.Count;
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobHistory.GetJobHistories;

public class GetUserJobHistoryQueryHandler : IQueryHandler<GetUserJobHistoriesQuery, JobHistoriesResponse> {
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IUserRepository _userRepository;

    public GetUserJobHistoryQueryHandler(IJobHistoryRepository jobHistoryRepository, IUserRepository userRepository) {
        _jobHistoryRepository = jobHistoryRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<JobHistoriesResponse>> Handle(
        GetUserJobHistoriesQuery request,
        CancellationToken cancellationToken
    ) {
        if (request.UserId.Value > 0 && _userRepository.FindById(request.UserId) is null)
            return Result.Failure<JobHistoriesResponse>(UserErrors.NotFound);
        var jobHistories = _jobHistoryRepository.GetAll(request.UserId);
        return !jobHistories.Any()
            ? Result.Failure<JobHistoriesResponse>(JobHistoryErrors.NotAny)
            : Result.Success(new JobHistoriesResponse(jobHistories.MapToDtos().ToList()));
    }
}
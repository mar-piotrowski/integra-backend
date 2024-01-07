using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobHistory.GetJobHistories;

public class GetUserJobHistoryQueryHandler : IQueryHandler<GetUserJobHistoriesQuery, List<JobHistoryDto>> {
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IUserRepository _userRepository;

    public GetUserJobHistoryQueryHandler(IJobHistoryRepository jobHistoryRepository, IUserRepository userRepository) {
        _jobHistoryRepository = jobHistoryRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<JobHistoryDto>>> Handle(
        GetUserJobHistoriesQuery request,
        CancellationToken cancellationToken
    ) {
        if (request.UserId.Value > 0 && _userRepository.GetById(request.UserId) is null)
            return Result.Failure<List<JobHistoryDto>>(UserErrors.NotFound);
        var jobHistories = await _jobHistoryRepository.GetAll(request.UserId);
        return !jobHistories.Any()
            ? Result.Failure<List<JobHistoryDto>>(JobHistoryErrors.NotAny)
            : jobHistories.MapToDtos().ToList();
    }
}
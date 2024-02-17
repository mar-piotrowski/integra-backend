using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.WorkingTime.UserStatistics;

public class
    GetUserWorkingTimeStatisticsQueryHandler : IQueryHandler<
    GetUserWorkingTimeStatisticsQuery,
    GetUserWorkingTimeStatisticsResponse
> {
    private readonly IUserRepository _userRepository;

    public GetUserWorkingTimeStatisticsQueryHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserWorkingTimeStatisticsResponse>> Handle(GetUserWorkingTimeStatisticsQuery request,
        CancellationToken cancellationToken) {
        if (request.Month <= 0 || request.Month > 12)
            return Result.Failure<GetUserWorkingTimeStatisticsResponse>(WorkingTimeErrors.WrongMonth);
        var user = _userRepository.FindWorkingTimes(request.UserId);
        if (user is null)
            return Result.Failure<GetUserWorkingTimeStatisticsResponse>(UserErrors.NotFound);
        if (!user.WorkingTimes.Any())
            return Result.Failure<GetUserWorkingTimeStatisticsResponse>(WorkingTimeErrors.NotFoundMany);
        var workingTimes = user.WorkingTimes.Where(workingTime =>
            workingTime.StartDate.Date.Year == request.Year
            && workingTime.StartDate.Date.Month == request.Month
        ).ToList();
        if (!workingTimes.Any())
            return Result.Failure<GetUserWorkingTimeStatisticsResponse>(WorkingTimeErrors.NotFoundForStats);
        var totalWorkedSeconds = workingTimes.Aggregate(0, (acc, curr) => acc += curr.TotalSeconds);
        var overSeconds = (totalWorkedSeconds- (168 * 3600));
        return Result.Success(new GetUserWorkingTimeStatisticsResponse(
            168,
            totalWorkedSeconds,
            overSeconds < 0 ? 0 : overSeconds
        ));
    }
}
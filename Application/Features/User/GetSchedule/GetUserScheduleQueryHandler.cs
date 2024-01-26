using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.GetSchedule;

public class GetUserScheduleQueryHandler : IQueryHandler<GetUserScheduleQuery, UserScheduleResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IScheduleService _scheduleService;

    public GetUserScheduleQueryHandler(IUserRepository userRepository, IScheduleService scheduleService) {
        _userRepository = userRepository;
        _scheduleService = scheduleService;
    }

    public async Task<Result<UserScheduleResponse>> Handle(
        GetUserScheduleQuery request,
        CancellationToken cancellationToken
    ) {
        var user = _userRepository.FindUserSchedules(request.UserId);
        if (user is null)
            return Result.Failure<UserScheduleResponse>(UserErrors.NotFound);
        var scheduleForYearExists = user.Schedules
            .FirstOrDefault(schedule =>
                schedule.ScheduleSchema.StartDate.Year == request.Year
            );
        if (scheduleForYearExists is null)
            return Result.Failure<UserScheduleResponse>(UserErrors.NoScheduleForYear);
        return Result.Success(new UserScheduleResponse(
            _scheduleService.CreateUserSchedule(user, request.Year, request.Month, request.OnlyWeek)
        ));
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.GetSchedules;

public class GetUsersScheduleQueryHandler : IQueryHandler<GetUsersScheduleQuery, UsersScheduleResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IScheduleService _scheduleService;
    
    public GetUsersScheduleQueryHandler(IUserRepository userRepository, IScheduleService scheduleService) {
        _userRepository = userRepository;
        _scheduleService = scheduleService;
    }

    public async Task<Result<UsersScheduleResponse>> Handle(
        GetUsersScheduleQuery request,
        CancellationToken cancellationToken
    ) {
        var users = _userRepository.FindUsersWithSchedule();
        if (!users.Any())
            return Result.Failure<UsersScheduleResponse>(UserErrors.NotFoundMany);
        var usersWithSchedule =
            _scheduleService.CreateUsersSchedule(users, request.Year, request.Month, request.OnlyWeek);
        return Result.Success(new UsersScheduleResponse(usersWithSchedule));
    }
}
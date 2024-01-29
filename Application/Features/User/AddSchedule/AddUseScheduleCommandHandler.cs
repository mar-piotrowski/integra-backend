using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.AddSchedule;

public class AddUseScheduleCommandHandler : ICommandHandler<AddUserScheduleCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUseScheduleCommandHandler(
        IUserRepository userRepository,
        IScheduleRepository scheduleRepository,
        IUnitOfWork unitOfWork
    ) {
        _userRepository = userRepository;
        _scheduleRepository = scheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddUserScheduleCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.FindUserSchedules(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        if(user.Schedules.Any())
            return Result.Failure(UserErrors.AlreadyHasSchedule);
        var schedule = _scheduleRepository.GetById(request.ScheduleSchemaId);
        if (schedule is null)
            return Result.Failure(ScheduleErrors.NotFound);
        user.AddSchedule(schedule);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
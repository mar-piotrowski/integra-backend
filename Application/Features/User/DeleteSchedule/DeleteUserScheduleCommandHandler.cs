using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.DeleteSchedule;

public class DeleteUserScheduleCommandHandler : ICommandHandler<DeleteUserScheduleCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserScheduleCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserScheduleCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.FindUserSchedules(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var schedule = user.Schedules.FirstOrDefault(schedule => schedule.ScheduleSchemaId == request.ScheduleSchemaId);
        if (schedule is null)
            return Result.Failure(ScheduleErrors.NotFound);
        user.RemoveSchedule(schedule.ScheduleSchema);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
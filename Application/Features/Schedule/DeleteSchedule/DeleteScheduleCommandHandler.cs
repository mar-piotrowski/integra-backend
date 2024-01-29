using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Schedule.DeleteSchedule;

public class DeleteScheduleCommandHandler : ICommandHandler<DeleteScheduleCommand> {
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteScheduleCommandHandler(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork) {
        _scheduleRepository = scheduleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken) {
        var schedule = _scheduleRepository.GetById(request.ScheduleSchemaId);
        if (schedule is null)
            return Result.Failure(ScheduleErrors.NotFound);
        _scheduleRepository.Remove(schedule);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
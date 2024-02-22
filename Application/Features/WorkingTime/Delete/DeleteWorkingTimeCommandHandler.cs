using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.WorkingTime.Delete;

public class DeleteWorkingTimeCommandHandler : ICommandHandler<DeleteWorkingTimeCommand> {
    private readonly IWorkingTimeRepository _workingTimeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository, IUnitOfWork unitOfWork) {
        _workingTimeRepository = workingTimeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWorkingTimeCommand request, CancellationToken cancellationToken) {
        var workingTime = _workingTimeRepository.FindById(request.WorkingTimeId);
        if (workingTime is null)
            return Result.Failure(WorkingTimeErrors.NotFound);
        _workingTimeRepository.Remove(workingTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
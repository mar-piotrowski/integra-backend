using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.WorkingTime.Edit;

public class EditWorkingTimeCommandHandler : ICommandHandler<EditWorkingTimeCommand> {
    private readonly IWorkingTimeRepository _workingTimeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditWorkingTimeCommandHandler(IWorkingTimeRepository workingTimeRepository, IUnitOfWork unitOfWork) {
        _workingTimeRepository = workingTimeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EditWorkingTimeCommand request, CancellationToken cancellationToken) {
        var workingTime = _workingTimeRepository.FindById(request.WorkingTimeId);
        if (workingTime is null)
            return Result.Failure(WorkingTimeErrors.NotFound);
        if (request.StartDate > request.EndDate)
            return Result.Failure(WorkingTimeErrors.WrongDates);
        workingTime.Update(request.StartDate, request.EndDate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.JobPosition.Command;

public class UpdateJobPositionCommandHandler : ICommandHandler<UpdateJobPositionCommand> {
    private readonly IJobPositionRepository _positionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateJobPositionCommandHandler(IUnitOfWork unitOfWork, IJobPositionRepository positionRepository) {
        _unitOfWork = unitOfWork;
        _positionRepository = positionRepository;
    }

    public async Task<Result> Handle(UpdateJobPositionCommand request, CancellationToken cancellationToken) {
        var title = _positionRepository.GetByTitle(request.Title);
        if (title is null)
            return Result.Failure(JobPositionErrors.TitleDoesNotExists);
        title.Update(request.Title);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.JobPosition.Command;

public class CreateJobPositionCommandHandler : ICommandHandler<CreateJobPositionCommand> {
    private readonly IJobPositionRepository _positionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobPositionCommandHandler(IJobPositionRepository positionRepository, IUnitOfWork unitOfWork) {
        _positionRepository = positionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateJobPositionCommand request, CancellationToken cancellationToken) {
        var title = _positionRepository.GetByTitle(request.Title);
        if (title is not null)
            return Result.Failure(JobPositionErrors.TitleExists);
        var jobPosition = Domain.Entities.JobPosition.Create(request.Title);
        _positionRepository.Add(jobPosition);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
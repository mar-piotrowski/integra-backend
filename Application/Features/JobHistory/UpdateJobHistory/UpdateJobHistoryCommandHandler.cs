using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobHistory.UpdateJobHistory;

public class UpdateJobHistoryCommandHandler : ICommandHandler<UpdateJobHistoryCommand> {
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateJobHistoryCommandHandler(IJobHistoryRepository jobHistoryRepository, IUserRepository userRepository,
        IUnitOfWork unitOfWork) {
        _jobHistoryRepository = jobHistoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateJobHistoryCommand command, CancellationToken cancellationToken) {
        var jobHistory = _jobHistoryRepository.FindById(command.JobHistoryId);
        if (jobHistory is null)
            return Result.Failure(JobHistoryErrors.NotFound);
        var jobHistoryUpdated = Domain.Entities.JobHistory.Create(
            command.CompanyName,
            command.Position,
            command.StartDate,
            command.EndDate
        );
        jobHistory.Update(jobHistoryUpdated);
        _jobHistoryRepository.Update(jobHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
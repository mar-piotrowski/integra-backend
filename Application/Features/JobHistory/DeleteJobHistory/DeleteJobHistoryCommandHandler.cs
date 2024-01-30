using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobHistory.DeleteJobHistory;

public class DeleteJobHistoryCommandHandler : ICommandHandler<DeleteJobHistoryCommand> {
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteJobHistoryCommandHandler(IJobHistoryRepository jobHistoryRepository, IUnitOfWork unitOfWork) {
        _jobHistoryRepository = jobHistoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteJobHistoryCommand request, CancellationToken cancellationToken) {
        var jobHistory = _jobHistoryRepository.FindById(request.JobHistoryId);
        if (jobHistory is null)
            return Result.Failure(JobHistoryErrors.NotFound);
        _jobHistoryRepository.Remove(jobHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
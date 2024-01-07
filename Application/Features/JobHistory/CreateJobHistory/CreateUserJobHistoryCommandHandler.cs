using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.JobHistory.CreateJobHistory;

public class CreateUserJobHistoryCommandHandler : ICommandHandler<CreateUserJobHistoryCommand> {
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserJobHistoryCommandHandler(IJobHistoryRepository jobHistoryRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _jobHistoryRepository = jobHistoryRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateUserJobHistoryCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var jobHistory = Domain.Entities.JobHistory.Create(request.CompanyName, request.Position, request.StartDate, request.EndDate);
        _jobHistoryRepository.Add(jobHistory);
        user.AddJobHistory(jobHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
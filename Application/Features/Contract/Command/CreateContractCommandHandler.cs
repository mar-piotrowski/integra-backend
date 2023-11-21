using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.Command;

public class CreateContractCommandHandler : ICommandHandler<CreateContractCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IContractRepository _contractRepository;
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContractCommandHandler(
        IUserRepository userRepository,
        IContractRepository contractRepository,
        IUnitOfWork unitOfWork, IJobPositionRepository jobPositionRepository) {
        _userRepository = userRepository;
        _contractRepository = contractRepository;
        _unitOfWork = unitOfWork;
        _jobPositionRepository = jobPositionRepository;
    }

    public async Task<Result> Handle(CreateContractCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(UserId.Create(request.UserId));
        if (user is null)
            return Result.Failure(UserErrors.UserDoesNotExists);
        var jobPosition = _jobPositionRepository.GetById(JobPositionId.Create(request.JobPositionId));
        if (jobPosition is null)
            return Result.Failure(JobPositionErrors.TitleDoesNotExists);
        var contract = Domain.Entities.Contract.Create(
            request.Salary,
            request.SignedOnDate,
            request.StartDate,
            request.EndDate,
            request.JobFund,
            request.Fgsp,
            request.PitExemption,
            request.ContractType,
            InsuranceCodeId.Create(request.InsuranceCodeId),
            UserId.Create(request.UserId),
            JobPositionId.Create(request.JobPositionId) 
        );
        _contractRepository.Add(contract);
        user.AddContract(contract);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
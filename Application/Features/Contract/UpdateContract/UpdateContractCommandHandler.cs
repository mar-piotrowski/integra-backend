using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.UpdateContract;

public class UpdateContractCommandHandler : ICommandHandler<UpdateContractCommand> {
    private readonly IContractRepository _contractRepository;
    private readonly IContractChangesRepository _changesRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContractCommandHandler(
        IContractRepository contractRepository,
        IJobPositionRepository jobPositionRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IContractChangesRepository changesRepository
    ) {
        _contractRepository = contractRepository;
        _jobPositionRepository = jobPositionRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _changesRepository = changesRepository;
    }

    public async Task<Result> Handle(UpdateContractCommand request, CancellationToken cancellationToken) {
        var contract = _contractRepository.FindById(request.ContractId);
        if (contract is null)
            return Result.Failure(ContractsErrors.NotFound);
        if (contract.Status == ContractStatus.NotActive)
            return Result.Failure(ContractsErrors.AlreadyTerminated);
        var user = _userRepository.FindById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.UserDoesNotExists);
        var jobPosition = _jobPositionRepository.GetByTitle(request.JobPositionId);
        if (jobPosition is null)
            return Result.Failure(JobPositionErrors.TitleDoesNotExists);
        var contractChanged = Domain.Entities.Contract.Create(
            request.SalaryWithTax,
            request.SalaryWithoutTax,
            request.WorkingHours1,
            request.WorkingHours2,
            request.SignedOnDate,
            null,
            null,
            request.JobFound,
            request.VoluntaryContribution,
            request.PensionFund,
            request.ProfitableFund,
            request.Fgsp,
            request.PitExemption,
            ContractType.ChangeContract,
            request.TaxRelief,
            request.InsuranceCodeId,
            request.UserId,
            jobPosition.Id,
            request.DeductibleCostId
        );
        _contractRepository.Add(contractChanged);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _changesRepository.Add(new ContractChange(request.ContractId, contractChanged.Id));
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
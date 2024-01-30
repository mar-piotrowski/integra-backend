using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Contract.TerminateContract;

public class TerminateContractCommandHandler : ICommandHandler<TerminateContractCommand> {
    private readonly IContractRepository _contractRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContractChangesRepository _contractChangesRepository;

    public TerminateContractCommandHandler(IContractRepository contractRepository, IUnitOfWork unitOfWork, IContractChangesRepository contractChangesRepository) {
        _contractRepository = contractRepository;
        _unitOfWork = unitOfWork;
        _contractChangesRepository = contractChangesRepository;
    }

    public async Task<Result> Handle(TerminateContractCommand request, CancellationToken cancellationToken) {
        var contract = _contractRepository.FindById(request.ContractId);
        if (contract is null)
            return Result.Failure(ContractsErrors.NotFound);
        if (contract.Status == ContractStatus.NotActive)
            return Result.Failure(ContractsErrors.AlreadyTerminated);
        var terminateContract = Domain.Entities.Contract.Create(
            0,
            0,
            0,
            0,
            request.TerminateDate,
            null,
            null,
            false,
            false,
            false,
            false,
            false,
            false,
            (ContractType)request.TerminateType,
            false,
            null,
            contract.UserId,
            null,
            null
        );
        contract.DeActive();
        _contractRepository.Add(terminateContract);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _contractChangesRepository.Add(new ContractChange(contract.Id, terminateContract.Id));
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contract.GetContractChanges;

public class GetContractChangesQueryHandler : IQueryHandler<GetContractChangesQuery, ContractChangesResponse> {
    private readonly IContractRepository _contractRepository;
    private readonly IContractChangesRepository _contractChangesRepository;
    private readonly ContractMapper _contractMapper;

    public GetContractChangesQueryHandler(
        IContractChangesRepository contractChangesRepository,
        IContractRepository contractRepository,
        ContractMapper contractMapper
    ) {
        _contractChangesRepository = contractChangesRepository;
        _contractRepository = contractRepository;
        _contractMapper = contractMapper;
    }

    public async Task<Result<ContractChangesResponse>> Handle(
        GetContractChangesQuery request,
        CancellationToken cancellationToken
    ) {
        var contract = _contractRepository.FindById(request.ContractId);
        if (contract is null)
            return Result.Failure<ContractChangesResponse>(ContractsErrors.NotFound);
        var changes = _contractChangesRepository.GetChangesForContract(request.ContractId);
        if (changes is null)
            return Result.Failure<ContractChangesResponse>(ContractsErrors.NotFoundChanges);
        return Result.Success(new ContractChangesResponse(_contractMapper.MapToDtos(changes).ToList()));
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contract.GetContracts;

public class GetContractsQueryHandler : IQueryHandler<GetContractsQuery, ContractsResponse> {
    private readonly IContractRepository _contractRepository;
    private readonly ContractMapper _contractMapper;

    public GetContractsQueryHandler(
        IContractRepository contractRepository,
        ContractMapper contractMapper
    ) {
        _contractRepository = contractRepository;
        _contractMapper = contractMapper;
    }

    public async Task<Result<ContractsResponse>> Handle(
        GetContractsQuery request,
        CancellationToken cancellationToken
    ) {
        var contracts = _contractRepository.GetAll(request.Queries).ToList();
        if (!contracts.Any())
            return Result.Failure<ContractsResponse>(ContractsErrors.NotFoundAny);
        return Result.Success(new ContractsResponse(_contractMapper.MapToDtos(contracts).ToList()));
    }
}
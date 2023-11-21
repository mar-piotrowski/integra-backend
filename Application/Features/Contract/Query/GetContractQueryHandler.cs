using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Contract.Query; 

public class GetContractQueryHandler : IQueryHandler<GetContractQuery, ContractDto> {
    private readonly IContractRepository _contractRepository;
    
    public GetContractQueryHandler(IContractRepository contractRepository) {
        _contractRepository = contractRepository;
    }

    public async Task<Result<ContractDto>> Handle(GetContractQuery request, CancellationToken cancellationToken) {
        var contract = _contractRepository.GetById(request.ContractId);
        if (contract is null)
            return Result.Failure<ContractDto>(ContractsErrors.NotFound);
        return Result.Success(contract.MapToDto());
    }
}
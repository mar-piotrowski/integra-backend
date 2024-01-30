using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contract.GetContract;

public class GetContractQueryHandler : IQueryHandler<GetContractQuery, ContractDto> {
    private readonly IContractRepository _contractRepository;
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly ContractMapper _contractMapper;

    public GetContractQueryHandler(
        IContractRepository contractRepository,
        IJobPositionRepository jobPositionRepository, ContractMapper contractMapper) {
        _contractRepository = contractRepository;
        _jobPositionRepository = jobPositionRepository;
        _contractMapper = contractMapper;
    }

    public async Task<Result<ContractDto>> Handle(GetContractQuery request, CancellationToken cancellationToken) {
        var contract = _contractRepository.FindById(request.ContractId);
        if (contract is null)
            return Result.Failure<ContractDto>(ContractsErrors.NotFound);
        return Result.Success(_contractMapper.MapToDto(contract));
    }
}
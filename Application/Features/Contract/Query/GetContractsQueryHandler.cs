using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Contract.Query;

public class GetContractsQueryHandler : IQueryHandler<GetContractsQuery, ContractsResponse> {
    private readonly IContractRepository _contractRepository;

    public GetContractsQueryHandler(IContractRepository contractRepository) {
        _contractRepository = contractRepository;
    }

    public async Task<Result<ContractsResponse>>
        Handle(GetContractsQuery request, CancellationToken cancellationToken) {
        var contracts = _contractRepository.GetAll();
        if (!contracts.Any())
            return Result.Failure<ContractsResponse>(ContractsErrors.NotFoundAny);
        return Result.Success(new ContractsResponse(contracts.MapToDtos().ToList()));
    }
}
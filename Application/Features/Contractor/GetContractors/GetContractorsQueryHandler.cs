using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contractor.GetContractors;

public class GetContractorsQueryHandler : IQueryHandler<GetContractorsQuery, ContractorsResponse> {
    private readonly IContractorRepository _contractorRepository;

    public GetContractorsQueryHandler(IContractorRepository contractorRepository) {
        _contractorRepository = contractorRepository;
    }

    public async Task<Result<ContractorsResponse>> Handle(
        GetContractorsQuery request,
        CancellationToken cancellationToken
    ) {
        var contractors = _contractorRepository.GetAllWithLocation();
        if (!contractors.Any())
            return Result.Failure<ContractorsResponse>(ContractorErrors.NotFoundMany);
        return Result.Success(new ContractorsResponse { Contractors = contractors.MapToDtos() });
    }
}
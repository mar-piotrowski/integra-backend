using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contractor.GetContractor;

public class GetContractorQueryHandler : IQueryHandler<GetContractorQuery, ContractorDto> {
    private readonly IContractorRepository _contractorRepository;

    public GetContractorQueryHandler(IContractorRepository contractorRepository) {
        _contractorRepository = contractorRepository;
    }

    public async Task<Result<ContractorDto>> Handle(
        GetContractorQuery request,
        CancellationToken cancellationToken
    ) {
        var contractor = _contractorRepository.FindByNip(request.Nip);
        if (contractor is null)
            return Result.Failure<ContractorDto>(ContractorErrors.NipExists);
        return Result.Success(contractor.MapToDto());
    }
}
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contractor.Get;

public class GetContractorQueryHandler : IQueryHandler<GetContractorQuery, ContractorDto> {
    private readonly IContractorRepository _contractorRepository;
    private readonly ContractorMapper _contractorMapper;

    public GetContractorQueryHandler(IContractorRepository contractorRepository, ContractorMapper contractorMapper) {
        _contractorRepository = contractorRepository;
        _contractorMapper = contractorMapper;
    }

    public async Task<Result<ContractorDto>> Handle(GetContractorQuery request, CancellationToken cancellationToken) {
        var contractor = _contractorRepository.FindByNip(request.Nip);
        return contractor is null
            ? Result.Failure<ContractorDto>(ContractorErrors.NipExists)
            : Result.Success(_contractorMapper.MapToDto(contractor));
    }
}
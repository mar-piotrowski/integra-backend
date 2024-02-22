using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contractor.GetAll;

public class GetContractorsQueryHandler : IQueryHandler<GetContractorsQuery, ContractorsResponse> {
    private readonly IContractorRepository _contractorRepository;
    private readonly ContractorMapper _contractorMapper;

    public GetContractorsQueryHandler(IContractorRepository contractorRepository, ContractorMapper contractorMapper) {
        _contractorRepository = contractorRepository;
        _contractorMapper = contractorMapper;
    }

    public async Task<Result<ContractorsResponse>> Handle(
        GetContractorsQuery request,
        CancellationToken cancellationToken
    ) {
        var contractors = _contractorRepository.GetAllWithLocation().ToList();
        return !contractors.Any()
            ? Result.Failure<ContractorsResponse>(ContractorErrors.NotFoundMany)
            : Result.Success(new ContractorsResponse(_contractorMapper.MapToDtos(contractors)));
    }
}
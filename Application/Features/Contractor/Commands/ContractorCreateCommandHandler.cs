using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contractor.Commands;

public class ContractorCreateCommandHandler : ICommandHandler<CreateContractorCommand> {
    private readonly IContractorRepository _contractorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ContractorCreateCommandHandler(IUnitOfWork unitOfWork, IContractorRepository contractorRepository) {
        _unitOfWork = unitOfWork;
        _contractorRepository = contractorRepository;
    }

    public async Task<Result> Handle(CreateContractorCommand request, CancellationToken cancellationToken) {
        var nipExists = _contractorRepository.FindByNip(Nip.Create(request.Nip));
        if (nipExists is not null)
            return Result.Failure(ContractorErrors.NipExists);
        var contractor = Domain.Entities.Contractor.Create(
            request.FullName,
            request.ShortName,
            request.Representative,
            Nip.Create(request.Nip),
            Location.Create(
                request.Location.Street,
                request.Location.HouseNo,
                request.Location.ApartmentNo,
                request.Location.PostalCode,
                request.Location.City,
                request.Location.Country,
                request.Location.IsPrivate,
                request.Location.IsCompany
            ),
            BankDetails.Create(request.BankDetails.Name, request.BankDetails.Number)
        );
        _contractorRepository.Add(contractor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
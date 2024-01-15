using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects;

namespace Application.Features.Contractor.UpdateContractor;

public class UpdateContractorCommandHandler : ICommandHandler<UpdateContractorCommand> {
    private readonly IContractorRepository _contractorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContractorCommandHandler(IContractorRepository contractorRepository, IUnitOfWork unitOfWork) {
        _contractorRepository = contractorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateContractorCommand request, CancellationToken cancellationToken) {
        var contractor = _contractorRepository.FindByNip(Nip.Create(request.Nip));
        if (contractor is null)
            return Result.Failure(ContractorErrors.NipNotExists);
        contractor.BankAccount.Update(request.BankAccount.Name, request.BankAccount.Number);
        contractor.Location.Update(
                request.Location.Street,
                request.Location.HouseNo,
                request.Location.ApartmentNo,
                request.Location.PostalCode,
                request.Location.City,
                request.Location.Country,
                request.Location.Province,
                request.Location.Commune,
                request.Location.District,
                request.Location.IsPrivate,
                request.Location.IsCompany
        );
        contractor.Update(
            request.FullName,
            request.ShortName,
            Email.Create(request.Email),
            Phone.Create(request.Phone)
        );
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
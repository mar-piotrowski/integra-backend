using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;
using Domain.ValueObjects;

namespace Application.Features.Contractor.Commands; 

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
        contractor.Update(request.FullName, request.ShortName, Email.Create(request.Email), request.Location, request.BankDetails);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
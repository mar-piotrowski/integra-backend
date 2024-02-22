using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Contractor.Delete;

public class DeleteContractorCommandHandler : ICommandHandler<DeleteContractorCommand> {
    private readonly IContractorRepository _contractorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContractorCommandHandler(IContractorRepository contractorRepository, IUnitOfWork unitOfWork) {
        _contractorRepository = contractorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteContractorCommand request, CancellationToken cancellationToken) {
        var contractor = _contractorRepository.FindById(request.ContractorId);
        if (contractor is null)
            return Result.Failure(ContractorErrors.NotFound);
        contractor.Disable();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.SchoolHistory.Commands;

public class DeleteSchoolHistoryCommandHandler : ICommandHandler<DeleteSchoolHistoryCommand> {
    private readonly ISchoolHistoryRepository _schoolHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSchoolHistoryCommandHandler(ISchoolHistoryRepository schoolHistoryRepository, IUnitOfWork unitOfWork) {
        _schoolHistoryRepository = schoolHistoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSchoolHistoryCommand request, CancellationToken cancellationToken) {
        var schoolHistory = _schoolHistoryRepository.GetById(request.SchoolHistoryId);
        if (schoolHistory is null)
            return Result.Failure(SchoolHistoryErrors.NotFound);
        _schoolHistoryRepository.Remove(schoolHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
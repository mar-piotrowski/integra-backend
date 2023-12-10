using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.SchoolHistory.Commands;

public class UpdateSchoolHistoryCommandHandler : ICommandHandler<UpdateSchoolHistoryCommand> {
    private readonly ISchoolHistoryRepository _schoolHistoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSchoolHistoryCommandHandler(ISchoolHistoryRepository schoolHistoryRepository, IUserRepository userRepository,
        IUnitOfWork unitOfWork) {
        _schoolHistoryRepository = schoolHistoryRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(UpdateSchoolHistoryCommand request, CancellationToken cancellationToken) {
        var schoolHistoryExists = _schoolHistoryRepository.GetById(request.SchoolHistoryId);
        if (schoolHistoryExists is null)
            return Result.Failure(SchoolHistoryErrors.NotFound);
        var schoolHistory = Domain.Entities.SchoolHistory.Create(
            request.SchoolName,
            request.Degree,
            request.Specialization,
            request.Title,
            request.StartDate,
            request.EndDate
        );
        _schoolHistoryRepository.UpdateById(request.SchoolHistoryId, schoolHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
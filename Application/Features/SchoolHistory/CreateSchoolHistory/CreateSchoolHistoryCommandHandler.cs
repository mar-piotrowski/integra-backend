using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.SchoolHistory.CreateSchoolHistory;

public class CreateSchoolHistoryCommandHandler : ICommandHandler<CreateUserSchoolHistoryCommand> {
    private readonly ISchoolHistoryRepository _schoolHistoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSchoolHistoryCommandHandler(ISchoolHistoryRepository schoolHistoryRepository,
        IUserRepository userRepository, IUnitOfWork unitOfWork) {
        _schoolHistoryRepository = schoolHistoryRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateUserSchoolHistoryCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var schoolHistory = Domain.Entities.SchoolHistory.Create(
            request.SchoolName,
            request.Degree,
            request.Specialization,
            request.Title,
            request.StartDate,
            request.EndDate
        );
        _schoolHistoryRepository.Add(schoolHistory);
        user.AddSchool(schoolHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
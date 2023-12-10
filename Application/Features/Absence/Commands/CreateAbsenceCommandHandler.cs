using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Commands;

public class CreateAbsenceCommandHandler : ICommandHandler<CreateAbsenceCommand> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAbsenceCommandHandler(
        IAbsenceRepository absenceRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    ) {
        _absenceRepository = absenceRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateAbsenceCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(UserId.Create(request.UserId));
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var absence = Domain.Entities.Absence.Create(
            request.StartDate,
            request.EndDate,
            request.DiseaseCode,
            request.Series,
            request.Number,
            request.ReleaseDate,
            request.DeliveryDate,
            request.Description
        );
        _absenceRepository.Add(absence);
        user.AddAbsence(absence);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
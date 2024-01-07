using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Absence.GetAbsences;

public class GetAbsencesQueryHandler : IQueryHandler<GetAbsencesQuery, AbsencesResponse> {
    private readonly IUserRepository _userRepository;
    private readonly IAbsenceRepository _absenceRepository;

    public GetAbsencesQueryHandler(IUserRepository userRepository, IAbsenceRepository absenceRepository) {
        _userRepository = userRepository;
        _absenceRepository = absenceRepository;
    }

    public async Task<Result<AbsencesResponse>> Handle(GetAbsencesQuery request, CancellationToken cancellationToken) {
        var absences = _absenceRepository.GetAllWithUser();
        if (!absences.Any())
            return Result.Failure<AbsencesResponse>(AbsenceErrors.NotFoundMany);
        return Result.Success(new AbsencesResponse(absences.MapToDtos().ToList()));
    }
}
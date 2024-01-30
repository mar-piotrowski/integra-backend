using Application.Abstractions.Messaging;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Absence.GetAll;

public class GetAbsencesQueryHandler : IQueryHandler<GetAbsencesQuery, AbsencesResponse> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly AbsenceMapper _absenceMapper;

    public GetAbsencesQueryHandler(IAbsenceRepository absenceRepository, AbsenceMapper absenceMapper) {
        _absenceRepository = absenceRepository;
        _absenceMapper = absenceMapper;
    }

    public async Task<Result<AbsencesResponse>> Handle(GetAbsencesQuery request, CancellationToken cancellationToken) {
        var absences = _absenceRepository.GetAll(request.UserId).ToList();
        return !absences.Any()
            ? Result.Failure<AbsencesResponse>(AbsenceErrors.NotFoundMany)
            : Result.Success(new AbsencesResponse(_absenceMapper.MapToDtos(absences).ToList()));
    }
}
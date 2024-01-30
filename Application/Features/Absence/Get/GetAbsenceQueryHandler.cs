using Application.Abstractions.Messaging;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Absence.Get;

public class GetAbsenceQueryHandler : IQueryHandler<GetAbsenceQuery, AbsenceDto> {
    private readonly IAbsenceRepository _absenceRepository;
    private readonly AbsenceMapper _absenceMapper;

    public GetAbsenceQueryHandler(IAbsenceRepository absenceRepository, AbsenceMapper absenceMapper) {
        _absenceRepository = absenceRepository;
        _absenceMapper = absenceMapper;
    }

    public async Task<Result<AbsenceDto>> Handle(GetAbsenceQuery request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.GetById(request.AbsenceId);
        return absence is null
            ? Result.Failure<AbsenceDto>(AbsenceErrors.NotFound)
            : Result.Success(_absenceMapper.MapToDto(absence));
    }
}
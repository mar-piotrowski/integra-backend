using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Absence.Queries;

public class GetAbsenceQueryHandler : IQueryHandler<GetAbsenceQuery, AbsenceDto> {
    private readonly IUserRepository _userRepository;
    private readonly IAbsenceRepository _absenceRepository;

    public GetAbsenceQueryHandler(IUserRepository userRepository, IAbsenceRepository absenceRepository) {
        _userRepository = userRepository;
        _absenceRepository = absenceRepository;
    }
    
    public async Task<Result<AbsenceDto>> Handle(GetAbsenceQuery request, CancellationToken cancellationToken) {
        var absence = _absenceRepository.GetByIdWithStatus(request.AbsenceId);
        if (absence is null)
            return Result.Failure<AbsenceDto>(AbsenceErrors.NotFound);
        return Result.Success(absence.MapToDto());
    }
}
using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class AbsenceMapper {
    private readonly UserMapper _userMapper;
    
    public AbsenceMapper(UserMapper userMapper) => _userMapper = userMapper;

    public AbsenceDto MapToDto(Absence absence) => new AbsenceDto {
        Id = absence.Id.Value,
        Type = absence.Type,
        User = _userMapper.MapToShortDto(absence.User),
        StartDate = absence.StartDate,
        EndDate = absence.EndDate,
        DiseaseCode = absence.DiseaseCode,
        Series = absence.Series,
        Number = absence.Number,
        Status = absence.Status
    };

    public IEnumerable<AbsenceDto> MapToDtos(IEnumerable<Absence> absences) => absences.Select(MapToDto);
}
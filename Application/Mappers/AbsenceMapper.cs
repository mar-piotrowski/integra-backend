using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class AbsenceMapper {
    public static AbsenceDto MapToDto(this Absence absence) => new AbsenceDto {
        Id = absence.Id.Value,
        // User = absence.User.MapToDto(),
        StartDate = absence.StartDate,
        EndDate = absence.EndDate,
        DiseaseCode = absence.DiseaseCode,
        Series = absence.Series,
        Number = absence.Number,
        Status = absence.Status.Status
    };

    public static IEnumerable<AbsenceDto> MapToDtos(this IEnumerable<Absence> absences) =>
        absences.Select(entry => entry.MapToDto());
}
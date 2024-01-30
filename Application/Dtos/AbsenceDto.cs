using Domain.Enums;

namespace Application.Dtos;

public class AbsenceDto {
    public int Id { get; set; }
    public AbsenceType Type { get; set; }
    public UserShortDto User { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? DiseaseCode { get; set; }
    public string? Series { get; set; }
    public string? Number { get; set; }
    public AbsenceStatus Status { get; set; }
}
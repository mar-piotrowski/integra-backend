using Domain.Enums;

namespace Application.Dtos;

public class AbsenceDto {
    public int Id { get; set; }
    public UserDto User { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? DiseaseCode { get; set; }
    public string Series { get; set; }
    public string Number { get; set; }
    public AbsenceStatus Status { get; set; }
}
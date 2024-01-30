using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Absence : Entity<AbsenceId> {
    public AbsenceType Type { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    public string? DiseaseCode { get; private set; }
    public string? Series { get; private set; }
    public string? Number { get; private set; }
    public string? Description { get; private set; }
    public AbsenceStatus Status { get; private set; } = AbsenceStatus.Pending;
    public UserId UserId { get; set; }
    public User User { get; set; }
    private Absence() { }

    public Absence(
        AbsenceType type,
        DateTimeOffset startDate,
        DateTimeOffset endDate,
        string? diseaseCode,
        string? series,
        string? number,
        string? description
    ) {
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        DiseaseCode = diseaseCode;
        Series = series;
        Number = number;
        Description = description;
    }

    public void Update(
        DateTimeOffset startDate,
        DateTimeOffset endDate,
        string? diseaseCode,
        string? series,
        string? number,
        string? description
    ) {
        StartDate = startDate;
        EndDate = endDate;
        DiseaseCode = diseaseCode;
        Series = series;
        Number = number;
        Description = description;
    }

    public void Accept() => Status = AbsenceStatus.Accepted;

    public void Reject() => Status = AbsenceStatus.Rejected;
}
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Absence : Entity<AbsenceId> {
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? DiseaseCode { get; private set; }
    public string Series { get; private set; }
    public string Number { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public DateTime DeliveryDate { get; private set; }
    public string Description { get; private set; }
    public AbsenceStatus Status { get; private set; }
    public UserId UserId { get; set; }
    public User User { get; set; }
    private Absence() { }

    private Absence(
        DateTime startDate,
        DateTime endDate,
        string? diseaseCode,
        string series,
        string number,
        DateTime releaseDate,
        DateTime deliveryDate,
        string description
    ) {
        StartDate = startDate;
        EndDate = endDate;
        DiseaseCode = diseaseCode;
        Series = series;
        Number = number;
        ReleaseDate = releaseDate;
        DeliveryDate = deliveryDate;
        Description = description;
        Status = AbsenceStatus.Create();
    }

    public static Absence Create(
        DateTime startDate,
        DateTime endDate,
        string? diseaseCode,
        string series,
        string number,
        DateTime releaseDate,
        DateTime deliveryDate,
        string description
    ) => new Absence(startDate, endDate, diseaseCode, series, number, releaseDate, deliveryDate, description);

    public void Accept(string description) => Status.Accept(description);

    public void Reject(string description) => Status.Reject(description);
}
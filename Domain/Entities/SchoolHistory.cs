using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class SchoolHistory : Entity<SchoolHistoryId> {
    public string SchoolName { get; private set; }
    public SchoolDegree Degree { get; private set; }
    public string? Specialization { get; private set; }
    public string? Title { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }

    private SchoolHistory() { }

    private SchoolHistory(
        string schoolName,
        SchoolDegree degree,
        string? specialization,
        string? title,
        DateTime startDate,
        DateTime endDate
    ) {
        SchoolName = schoolName;
        Degree = degree;
        Specialization = specialization;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static SchoolHistory Create(
        string schoolName,
        SchoolDegree degree,
        string? specialization,
        string? title,
        DateTime startDate,
        DateTime endDate
    ) => new SchoolHistory(schoolName, degree, specialization, title, startDate, endDate);

    public void Update(SchoolHistory schoolHistory) {
        SchoolName = schoolHistory.SchoolName;
        Degree = schoolHistory.Degree;
        Specialization = schoolHistory.Specialization;
        Title = schoolHistory.Title;
        StartDate = schoolHistory.StartDate;
        EndDate = schoolHistory.EndDate;
    }
}
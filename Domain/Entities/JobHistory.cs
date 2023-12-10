using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class JobHistory : Entity<JobHistoryId> {
    public string CompanyName { get; private set; }
    public string Position { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }

    private JobHistory() { }

    private JobHistory(string companyName, string position, DateTime startDate, DateTime endDate) {
        CompanyName = companyName;
        Position = position;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static JobHistory Create(string companyName, string position, DateTime startDate, DateTime endDate) =>
        new JobHistory(companyName, position, startDate, endDate);

    public void Update(JobHistory jobHistory) {
        CompanyName = jobHistory.CompanyName;
        Position = jobHistory.Position;
        StartDate = jobHistory.StartDate;
        EndDate = jobHistory.EndDate;
    }
}
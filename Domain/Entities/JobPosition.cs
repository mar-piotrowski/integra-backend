using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class JobPosition : Entity<JobPositionId> {
    public string Title { get; private set; }

    private JobPosition() { }

    private JobPosition(string title) {
        Title = title;
    }

    public static JobPosition Create(string title) => new JobPosition(title);

    public void Update(string title) => Title = title;
}
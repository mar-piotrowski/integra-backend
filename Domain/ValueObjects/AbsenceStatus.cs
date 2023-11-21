using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.ValueObjects;

public class AbsenceStatus : ValueObject {
    public Enums.AbsenceStatus Status { get; private set; }
    public string Description { get; private set; }
    public AbsenceId AbsenceId { get; private set; }

    private AbsenceStatus(Enums.AbsenceStatus status, string description) {
        Status = status;
        Description = description;
    }

    public static AbsenceStatus Create() =>
        new AbsenceStatus(Enums.AbsenceStatus.Pending, string.Empty);


    public void Accept(string description) {
        Status = Enums.AbsenceStatus.Accepted;
        Description = description;
    }

    public void Reject(string description) {
        Status = Enums.AbsenceStatus.Rejected;
        Description = description;
    }

    protected override IEnumerable<object> GetAtomicValues() {
        yield return Status;
        yield return AbsenceId;
    }
}
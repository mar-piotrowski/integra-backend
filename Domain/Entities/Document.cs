using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Document : Entity<DocumentId> {
    public DocumentType Type { get; private set; }
    public DateTimeOffset IssueDate { get; private set; }
    public DateTimeOffset ReceptionDate { get; private set; }
    public DateTimeOffset PaymentDate { get; private set; }
    public ContractorId ContractorId { get; private set; }
    public string? Description { get; private set; }
    public Contractor Contract { get; private set; }

    public List<DocumentArticles> Articles { get; private set; } = new List<DocumentArticles>();

    public Document(
        DocumentType type,
        DateTimeOffset issueDate,
        DateTimeOffset receptionDate,
        DateTimeOffset paymentDate,
        ContractorId contractorId,
        string? description
    ) {
        Type = type;
        IssueDate = issueDate;
        ReceptionDate = receptionDate;
        PaymentDate = paymentDate;
        ContractorId = contractorId;
        Description = description;
    }
}
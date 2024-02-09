using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Document : Entity<DocumentId> {
    public DocumentType Type { get; private set; }
    public string Number { get; private set; }
    public DateTimeOffset IssueDate { get; private set; }
    public DateTimeOffset? ReceptionDate { get; private set; }
    public DateTimeOffset? PaymentDate { get; private set; }
    public PaymentMethod? PaymentMethod { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalAmountWithTax { get; private set; }
    public decimal TotalAmountWithoutTax { get; private set; }
    public string? Description { get; private set; }
    public bool Locked { get; private set; }
    public StockId? SourceStockId { get; private set; }
    public StockId? TargetStockId { get; private set; }
    public ContractorId? ContractorId { get; private set; }
    public Contractor? Contractor { get; private set; }
    public Stock? SourceStock { get; private set; }
    public Stock? TargetStock { get; private set; }

    public List<DocumentArticles> Articles { get; private set; } = new List<DocumentArticles>();

    public Document(
        DocumentType type,
        string number,
        DateTimeOffset issueDate,
        DateTimeOffset? receptionDate,
        DateTimeOffset? paymentDate,
        PaymentMethod? paymentMethod,
        decimal discount,
        decimal totalAmountWithTax,
        decimal totalAmountWithoutTax,
        string? description,
        bool locked,
        ContractorId? contractorId,
        StockId? sourceStockId,
        StockId? targetStockId
    ) {
        Type = type;
        Number = number;
        IssueDate = issueDate;
        ReceptionDate = receptionDate;
        PaymentDate = paymentDate;
        PaymentMethod = paymentMethod;
        Discount = discount;
        TotalAmountWithTax = totalAmountWithTax;
        TotalAmountWithoutTax = totalAmountWithoutTax;
        Description = description;
        Locked = locked;
        ContractorId = contractorId;
        SourceStockId = sourceStockId;
        TargetStockId = targetStockId;
    }

    public void Update(
        string number,
        DateTimeOffset issueDate,
        DateTimeOffset? receptionDate,
        DateTimeOffset? paymentDate,
        PaymentMethod? paymentMethod,
        decimal discount,
        decimal totalAmountWithTax,
        decimal totalAmountWithoutTax,
        bool locked,
        ContractorId? contractorId,
        StockId? sourceStockId,
        StockId? targetStockId,
        string? description
    ) {
        Number = number;
        IssueDate = issueDate;
        ReceptionDate = receptionDate;
        PaymentDate = paymentDate;
        PaymentMethod = paymentMethod;
        Discount = discount;
        TotalAmountWithTax = totalAmountWithTax;
        TotalAmountWithoutTax = totalAmountWithoutTax;
        Locked = locked;
        ContractorId = contractorId;
        SourceStockId = sourceStockId;
        TargetStockId = targetStockId;
        Description = description;
    }

    public void AddArticles(List<StockArticleChangeDto> articles) {
        foreach (var article in articles)
            Articles.Add(new DocumentArticles(Id, article.ArticleId, article.Amount));
    }

    public void AddArticle(Article article, decimal amount) =>
        Articles.Add(new DocumentArticles(this, article, amount));

    public void ClearArticles() => Articles.Clear();

    public void Lock() => Locked = true;
}
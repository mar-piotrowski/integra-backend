namespace Application.Dtos;

public record EditDocumentRequest (
    string Number,
    DateTimeOffset IssueDate,
    DateTimeOffset? ReceptionDate,
    DateTimeOffset? PaymentDate,
    decimal Discount,
    decimal TotalAmountWithTax,
    decimal TotalAmountWithoutTax, 
    string? Description,
    bool Locked,
    List<CreateDocumentArticleDto> Articles,
    int ContractorId,
    int SourceStockId,
    int TargetStockId
);
using Domain.Enums;

namespace Application.Dtos;

public record EditDocumentRequest (
    string Number,
    DateTimeOffset IssueDate,
    DateTimeOffset? ReceptionDate,
    DateTimeOffset? PaymentDate,
    PaymentMethod PaymentMethod,
    decimal Discount,
    decimal TotalAmountWithTax,
    decimal TotalAmountWithoutTax, 
    string? Description,
    List<CreateDocumentArticleDto> Articles,
    bool Locked,
    int? ContractorId,
    int? SourceStockId,
    int? TargetStockId
);
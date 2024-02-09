using Domain.Enums;

namespace Application.Dtos;

public record DocumentDto(
    int Id,
    DocumentType Type,
    string Number,
    DateTimeOffset IssueDate,
    DateTimeOffset? ReceptionDate,
    DateTimeOffset? PaymentDate,
    decimal Discount,
    decimal TotalAmountWithTax,
    decimal TotalAmountWithoutTax,
    string? Description,
    bool Locked,
    List<DocumentArticleDto> Articles,
    ContractorDto? Contractor,
    StockDto? SourceStock,
    StockDto? TargetStock
);
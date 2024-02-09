using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Edit;

public record EditDocumentCommand (
    DocumentId DocumentId,
    string Number,
    DateTimeOffset IssueDate,
    DateTimeOffset? ReceptionDate,
    DateTimeOffset? PaymentDate,
    PaymentMethod? PaymentMethod,
    decimal Discount,
    decimal TotalAmountWithTax,
    decimal TotalAmountWithoutTax, 
    string? Description,
    bool Locked,
    List<CreateDocumentArticleDto> Articles,
    ContractorId? ContractorId,
    StockId? SourceStockId,
    StockId? TargetStockId
) : ICommand;
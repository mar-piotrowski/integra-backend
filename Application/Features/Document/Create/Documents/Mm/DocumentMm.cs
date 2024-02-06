using Application.Abstractions.Repositories;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Create.Documents.Mm;

public class DocumentMm : IDocumentMm {
    private readonly IStockRepository _stockRepository;

    public DocumentMm(IStockRepository stockRepository) {
        _stockRepository = stockRepository;
    }

    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.SourceStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockIsRequired);
        if (command.TargetStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.TargetStockIsRequired);
        var sourceStock = _stockRepository.FindById(command.SourceStockId);
        if (sourceStock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockNotFound);
        var targetStock = _stockRepository.FindById(command.TargetStockId);
        if (targetStock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.TargetStockNotFound);
        var document = new Domain.Entities.Document(
            DocumentType.Mm,
            command.Number,
            command.IssueDate,
            command.ReceptionDate,
            command.PaymentDate,
            command.Discount,
            command.TotalAmountWithoutTax,
            command.TotalAmountWithTax,
            command.Description,
            command.Locked,
            command.ContractorId,
            command.SourceStockId,
            command.TargetStockId
        );
        var articles = command.Articles.MapToAddArticles(); 
        document.AddArticles(articles);
        sourceStock.OddAmountArticles(articles);
        targetStock.AddArticles(articles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(EditDocumentCommand command) {
        throw new NotImplementedException();
    }
}
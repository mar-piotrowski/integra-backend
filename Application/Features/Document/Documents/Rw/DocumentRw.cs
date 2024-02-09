using Application.Abstractions.Repositories;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Document.Documents.Rw;

public class DocumentRw : IDocumentRw {
    private readonly IStockRepository _stockRepository;

    public DocumentRw(IStockRepository stockRepository) {
        _stockRepository = stockRepository;
    }
    
    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.SourceStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockIsRequired);
        var sourceStock = _stockRepository.FindById(command.SourceStockId);
        if (sourceStock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockNotFound);
        var document = new Domain.Entities.Document(
            DocumentType.Mm,
            command.Number,
            command.IssueDate,
            command.ReceptionDate,
            command.PaymentDate,
            command.PaymentMethod,
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
        sourceStock.RemoveArticles(articles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command) {
        throw new NotImplementedException();
    }
}
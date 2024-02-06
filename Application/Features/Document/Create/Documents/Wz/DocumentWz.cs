using Application.Abstractions.Repositories;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Document.Create.Documents.Wz;

public class DocumentWz : IDocumentWz {
    private readonly IStockRepository _stockRepository;

    public DocumentWz(IStockRepository stockRepository) {
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

    public Result<Domain.Entities.Document> Edit(EditDocumentCommand command) {
        throw new NotImplementedException();
    }
}
using Application.Abstractions.Repositories;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.Document.Documents.Pw;

public class DocumentPw : IDocument {
    private readonly IStockRepository _stockRepository;
    private readonly ArticleMapper _articleMapper;

    public DocumentPw(IStockRepository stockRepository, ArticleMapper articleMapper) {
        _stockRepository = stockRepository;
        _articleMapper = articleMapper;
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
        var articles = _articleMapper.MapToAddArticles(command.Articles);
        document.AddArticles(articles);
        sourceStock.AddArticles(articles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document,EditDocumentCommand command) {
        throw new NotImplementedException();
    }
}
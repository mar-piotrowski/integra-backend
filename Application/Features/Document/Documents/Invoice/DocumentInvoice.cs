using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Documents.Invoice;

public class DocumentInvoice : IDocumentInvoice {
    private readonly IStockRepository _stockRepository;
    private readonly IContractorRepository _contractorRepository;
    private readonly ArticleMapper _articleMapper;

    public DocumentInvoice(
        IContractorRepository contractorRepository,
        IStockRepository stockRepository,
        ArticleMapper articleMapper
    ) {
        _contractorRepository = contractorRepository;
        _stockRepository = stockRepository;
        _articleMapper = articleMapper;
    }

    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        var document = new Domain.Entities.Document(
            DocumentType.Invoice,
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
        document.AddArticles(_articleMapper.MapToAddArticles(command.Articles));
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        document.Update(
            command.Number,
            command.IssueDate,
            command.ReceptionDate,
            command.PaymentDate,
            command.PaymentMethod,
            command.Discount,
            command.TotalAmountWithoutTax,
            command.TotalAmountWithTax,
            command.Locked,
            command.ContractorId,
            command.SourceStockId,
            command.TargetStockId,
            command.Description
        );
        document.ClearArticles();
        document.AddArticles(_articleMapper.MapToAddArticles(command.Articles));
        return document;
    }

    private Result<Domain.Entities.Document> ProductsAvailableOnStock(
        List<CreateDocumentArticleDto> articles,
        StockId sourceStockId
    ) {
        var stock = _stockRepository.FindById(sourceStockId);
        if (stock is null)
            return (Result<Domain.Entities.Document>)Result.Failure(StockErrors.NotFound);
        foreach (var article in articles) {
            var stockArticle = stock
                .Articles
                .FirstOrDefault(stockArticle => stockArticle.StockId == ArticleId.Create(article.Id));
            if (stockArticle is null)
                return Result.Failure<Domain.Entities.Document>(StockErrors.NoArticleOnStock);
            if (stockArticle.Amount < article.Amount)
                return Result.Failure<Domain.Entities.Document>(
                    StockErrors.NotEnoughAmountOnStock(stockArticle.Article.Name, stockArticle.Amount));
        }

        return (Result<Domain.Entities.Document>)Result.Success();
    }
}
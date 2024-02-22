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
    private readonly IArticleRepository _articleRepository;
    private readonly ArticleMapper _articleMapper;

    public DocumentInvoice(
        IContractorRepository contractorRepository,
        IStockRepository stockRepository,
        ArticleMapper articleMapper,
        IArticleRepository articleRepository
    ) {
        _contractorRepository = contractorRepository;
        _stockRepository = stockRepository;
        _articleMapper = articleMapper;
        _articleRepository = articleRepository;
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
        if (command.Locked) {
            var productsValidation = ProductsAvailableOnStock(command.Articles);
            if (productsValidation.IsFailure)
                return productsValidation;
        }

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
        if (command.Locked) {
            var productsValidation = ProductsAvailableOnStock(command.Articles);
            if (productsValidation.IsFailure)
                return productsValidation;
        }

        document.ClearArticles();
        document.AddArticles(_articleMapper.MapToAddArticles(command.Articles));
        return document;
    }

    private Result<Domain.Entities.Document> ProductsAvailableOnStock(List<CreateDocumentArticleDto> articles) {
        foreach (var article in articles) {
            var articlesAmount = _stockRepository.CountArticleOnStocks(ArticleId.Create(article.Id));
            var stockArticle = _articleRepository.FindById(ArticleId.Create(article.Id));
            if (stockArticle is null)
                return Result.Failure<Domain.Entities.Document>(StockErrors.NoArticleOnStock);
            if (articlesAmount < article.Amount)
                return Result.Failure<Domain.Entities.Document>(
                    StockErrors.NotEnoughAmountOnStock(stockArticle.Name, articlesAmount));
        }

        return (Result<Domain.Entities.Document>)Result.Success();
    }
}
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Documents.Mm;

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
        var productsOnStock = ProductsAvailableOnStock(command.Articles, command.SourceStockId);
        if (productsOnStock.IsFailure)
            return productsOnStock;
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
        if (!document.Locked) {
            document.AddArticles(articles);
            return document;
        }

        sourceStock.OddAmountArticles(articles);
        targetStock.AddArticles(articles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command) {
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
        var productsOnStock = ProductsAvailableOnStock(command.Articles, command.SourceStockId);
        if (productsOnStock.IsFailure)
            return productsOnStock;
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
        var articles = command.Articles.MapToAddArticles();
        if (!command.Locked) {
            document.ClearArticles();
            document.AddArticles(articles);
            return document;
        }

        sourceStock.OddAmountArticles(articles);
        targetStock.AddArticles(articles);
        return document;
    }

    private Result<Domain.Entities.Document> ProductsAvailableOnStock(List<CreateDocumentArticleDto> articles,
        StockId sourceStockId) {
        var stock = _stockRepository.FindById(sourceStockId);
        if (stock is null)
            return (Result<Domain.Entities.Document>)Result.Failure(StockErrors.NotFound);
        foreach (var article in articles) {
            var stockArticle = stock
                .Articles
                .FirstOrDefault(stockArticle => stockArticle.ArticleId == ArticleId.Create(article.Id));
            if (stockArticle is null)
                return Result.Failure<Domain.Entities.Document>(StockErrors.NoArticleOnStock);
            if (stockArticle.Amount < article.Amount)
                return Result.Failure<Domain.Entities.Document>(
                    StockErrors.NotEnoughAmountOnStock(stockArticle.Article.Name, stockArticle.Amount));
        }

        return Result.Success<Domain.Entities.Document>();
    }
}
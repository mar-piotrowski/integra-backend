using Application.Abstractions.Repositories;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Documents.Pz;

public class DocumentPz : IDocumentPz {
    private readonly IContractorRepository _contractorRepository;
    private readonly IStockRepository _stockRepository;

    public DocumentPz(IContractorRepository contractorRepository, IStockRepository stockRepository) {
        _contractorRepository = contractorRepository;
        _stockRepository = stockRepository;
    }

    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        if (command.SourceStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockIsRequired);
        var stock = _stockRepository.FindById(command.SourceStockId);
        if (stock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.NotFound);
        var addArticles = command.Articles
            .Select(article => new StockArticleChangeDto(ArticleId.Create(article.Id), article.Amount))
            .ToList();
        var document = new Domain.Entities.Document(
            DocumentType.Pz,
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
        if (!command.Locked) {
            document.AddArticles(addArticles);
            return document;
        }

        stock.AddArticles(addArticles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        if (command.SourceStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.SourceStockIsRequired);
        var stock = _stockRepository.FindById(command.SourceStockId);
        if (stock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.NotFound);
        var addArticles = command.Articles
            .Select(article => new StockArticleChangeDto(ArticleId.Create(article.Id), article.Amount))
            .ToList();
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
        if (!command.Locked) {
            document.AddArticles(addArticles);
            return document;
        }

        stock.AddArticles(addArticles);
        return document;
    }
}
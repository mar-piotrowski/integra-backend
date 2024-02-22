using Application.Abstractions.Repositories;
using Application.Features.Document.Create;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Documents.Pz;

public class DocumentPz : IDocumentPz {
    private readonly IContractorRepository _contractorRepository;
    private readonly IStockRepository _stockRepository;
    private readonly ArticleMapper _articleMapper;

    public DocumentPz(
        IContractorRepository contractorRepository, IStockRepository stockRepository,
        ArticleMapper articleMapper) {
        _contractorRepository = contractorRepository;
        _stockRepository = stockRepository;
        _articleMapper = articleMapper;
    }

    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        if (command.TargetStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.TargetStockIsRequired);
        var stock = _stockRepository.FindById(command.TargetStockId);
        if (stock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.NotFound);
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
        var articles = _articleMapper.MapToAddArticles(command.Articles);
        if (command.Locked) 
            stock.AddArticles(articles);
        document.AddArticles(articles);
        return document;
    }

    public Result<Domain.Entities.Document> Edit(Domain.Entities.Document document, EditDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        if (command.TargetStockId is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.TargetStockIsRequired);
        var stock = _stockRepository.FindById(command.TargetStockId);
        if (stock is null)
            return Result.Failure<Domain.Entities.Document>(StockErrors.NotFound);
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
        var articles = _articleMapper.MapToAddArticles(command.Articles);
        if (!command.Locked) {
            document.ClearArticles();
            document.AddArticles(articles);
            return document;
        }

        stock.AddArticles(articles);
        return document;
    }
}
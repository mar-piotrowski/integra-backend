using Application.Abstractions.Repositories;
using Application.Features.Document.Edit;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Create.Documents.Invoice;

public class DocumentInvoice : IDocumentInvoice {
    private readonly IArticleRepository _articleRepository;
    private readonly IContractorRepository _contractorRepository;

    public DocumentInvoice(IArticleRepository articleRepository, IContractorRepository contractorRepository) {
        _articleRepository = articleRepository;
        _contractorRepository = contractorRepository;
    }

    public Result<Domain.Entities.Document> Create(CreateDocumentCommand command) {
        if (command.ContractorId is null || _contractorRepository.FindById(command.ContractorId) is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.ContractorIsRequired);
        if (command.PaymentMethod is null)
            return Result.Failure<Domain.Entities.Document>(DocumentErrors.PaymentMethodIsRequired);
        var document = new Domain.Entities.Document(
            DocumentType.Invoice,
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
        document.AddArticles(command.Articles.MapToAddArticles());
        return document;
    }

    public Result<Domain.Entities.Document> Edit(EditDocumentCommand command) {
        throw new NotImplementedException();
    }
}
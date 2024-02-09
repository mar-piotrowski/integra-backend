using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Features.Document.Documents;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Edit;

public class EditDocumentCommandHandler : ICommandHandler<EditDocumentCommand> {
    private readonly IDocumentRepository _documentRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IDocumentFactory _documentFactory;
    private readonly IUnitOfWork _unitOfWork;

    public EditDocumentCommandHandler(
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork,
        IDocumentFactory documentFactory,
        IArticleRepository articleRepository
    ) {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
        _documentFactory = documentFactory;
        _articleRepository = articleRepository;
    }

    public async Task<Result> Handle(EditDocumentCommand request, CancellationToken cancellationToken) {
        var document = _documentRepository.FindById(request.DocumentId);
        if (document is null)
            return Result.Failure(DocumentErrors.NotFound);
        var articles = _articleRepository
            .FindByIds(request.Articles.Select(article => ArticleId.Create(article.Id)));
        var availableArticlesResult = DocumentUtils.HasAvailableArticles(articles, request.Articles);
        if (availableArticlesResult.IsFailure)
            return availableArticlesResult;
        var documentEdited = _documentFactory.ChooseDocument(document.Type).Edit(document, request);
        if (documentEdited.IsFailure)
            return documentEdited;
        _documentRepository.Update(documentEdited.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
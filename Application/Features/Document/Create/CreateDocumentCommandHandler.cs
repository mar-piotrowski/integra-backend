using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Document.Create.Documents;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Create;

public class CreateDocumentCommandHandler : ICommandHandler<CreateDocumentCommand> {
    private readonly IDocumentRepository _documentRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IDocumentFactory _documentFactory;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDocumentCommandHandler(
        IDocumentRepository documentRepository,
        IArticleRepository articleRepository,
        IDocumentFactory documentFactory,
        IUnitOfWork unitOfWork
    ) {
        _documentRepository = documentRepository;
        _articleRepository = articleRepository;
        _documentFactory = documentFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateDocumentCommand request, CancellationToken cancellationToken) {
        var documentExists = _documentRepository.FindByNumber(request.Number);
        if (documentExists is not null)
            return Result.Failure(DocumentErrors.Exists);
        var articles = _articleRepository
            .FindByIds(request.Articles.Select(article => ArticleId.Create(article.Id)));
        var availableArticlesResult = DocumentUtils.HasAvailableArticles(articles, request.Articles);
        if (availableArticlesResult.IsFailure)
            return availableArticlesResult;
        var document = _documentFactory.ChooseDocument(request.Type).Create(request);
        if (document.IsFailure)
            return document;
        _documentRepository.Add(document.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
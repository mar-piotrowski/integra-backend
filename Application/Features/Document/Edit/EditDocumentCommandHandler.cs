using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Edit;

public class EditDocumentCommandHandler : ICommandHandler<EditDocumentCommand> {
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork) {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EditDocumentCommand request, CancellationToken cancellationToken) {
        var document = _documentRepository.FindById(request.DocumentId);
        if (document is null)
            return Result.Failure(DocumentErrors.NotFound);
        // var availableArticles = HasAvailableArticles(request.Articles);
        // if (availableArticles.IsFailure)
        //     return availableArticles;
        // document.Update(
        //     request.Number,
        //     request.IssueDate,
        //     request.ReceptionDate,
        //     request.PaymentDate,
        //     request.Discount,
        //     request.TotalAmountWithoutTax,
        //     request.TotalAmountWithTax,
        //     request.Description,
        //     request.ContractorId,
        //     request.SourceStockId,
        //     request.TargetStockId
        // );
        // UpdateArticles(document, request.Articles);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
    //
    // private void UpdateArticles(Document document, List<CreateDocumentArticleDto> articles) {
    //     document.ClearArticles();
    //     AddArticles(document, articles);
    // }
    //
    // private Result HasAvailableArticles(List<CreateDocumentArticleDto> articlesToAdd) {
    //     var articles = _articleRepository.FindAll().ToList();
    //     foreach (var requestArticle in articlesToAdd)
    //         if (!articles.Exists(article => article.Id == ArticleId.Create(requestArticle.ArticleId)))
    //             return Result.Failure(ArticleErrors.NotFound);
    //     return Result.Success();
    // }
    //
    // private void AddArticles(Document document, List<CreateDocumentArticleDto> articlesToAdd) {
    //     var articlesToAddSortedById = articlesToAdd
    //         .OrderBy(article => article.ArticleId)
    //         .ToList();
    //     var articles = _articleRepository
    //         .FindByIds(articlesToAdd.Select(article => ArticleId.Create(article.ArticleId)))
    //         .OrderBy(article => article.Id)
    //         .ToList();
    //     for (var i = 0; i < articles.Count; i++)
    //         document.AddArticle(articles[i], articlesToAddSortedById[i].Amount);
    // }
}
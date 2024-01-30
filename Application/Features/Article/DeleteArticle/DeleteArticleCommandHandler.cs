using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.DeleteArticle; 

public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand> {
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteArticleCommandHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork) {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken) {
        var article = _articleRepository.FindById(request.Id);
        if (article is null)
            return Result.Failure(ArticleErrors.NotFound);
        article.Disable();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
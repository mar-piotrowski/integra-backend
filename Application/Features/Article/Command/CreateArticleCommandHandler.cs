using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Article.Command;

public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand> {
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateArticleCommandHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork) {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateArticleCommand request, CancellationToken cancellationToken) {
        var codeExits = _articleRepository.GetByCode(request.Code);
        if (codeExits is not null)
            return Result.Failure(ArticleErrors.ArticleWithCodeExists);
        var article = Domain.Entities.Article.Create(
            request.Name,
            request.Code,
            request.Gtin,
            request.MeasureUnit,
            request.Pkwiu,
            request.Description
        );
        _articleRepository.Add(article);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
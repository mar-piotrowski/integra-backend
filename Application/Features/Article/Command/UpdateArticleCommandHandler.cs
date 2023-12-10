using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Article.Command; 

public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand> {
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateArticleCommandHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork) {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(UpdateArticleCommand request, CancellationToken cancellationToken) {
        var user = _articleRepository.GetById(request.Id);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        return Result.Success();
    }
}
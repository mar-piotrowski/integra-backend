using Application.Abstractions.Messaging;
using Domain.Common.Result;

namespace Application.Features.Article.DeleteArticle; 

public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand> {
    public Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
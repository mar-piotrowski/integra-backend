using Application.Abstractions.Messaging;
using Domain.Result;

namespace Application.Features.Article.Command; 

public class DeleteArticleCommandHandler : ICommandHandler<DeleteArticleCommand> {
    public Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
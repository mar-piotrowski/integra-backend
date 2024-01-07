using Application.Abstractions.Messaging;
using Domain.Common.Result;

namespace Application.Features.User.StartWork;

public class StartWorkUserCommandHandler : ICommandHandler<StartWorkUserCommand> {
    public async Task<Result> Handle(StartWorkUserCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
using Domain.Result;
using MediatR;

namespace Application.Features.User.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result> {

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        // var user = _databaseContext.Users
        //     .Include(l => l.Locations)
        //     .FirstOrDefault(u => u.Id == request.UserId);
        // if (user is null)
        //     return Result.Fail(new NotFoundError("użytkownika"));
        // var updatedUser = user.MapUpdateUser(request.User);
        // _databaseContext.Users.Update(updatedUser);
        // await _databaseContext.SaveChangesAsync(cancellationToken);
        // return Result.Ok();
        throw new NotImplementedException();
    }
}
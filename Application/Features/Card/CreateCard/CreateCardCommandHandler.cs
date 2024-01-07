using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.CreateCard;

public class CreateCardCommandHandler : ICommandHandler<CreateCardCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCardCommandHandler(
        ICardRepository cardRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    ) {
        _cardRepository = cardRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCardCommand request, CancellationToken cancellationToken) {
        var user = _userRepository.GetById(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        var card = _cardRepository.GetByNumber(request.Number);
        if (card is not null)
            return Result.Failure(CardErrors.Exists);
        var newCard = Domain.Entities.Card.Create(request.UserId, request.Number);
        _cardRepository.Add(newCard);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Delete;

public class DeleteDocumentCommandHandler : ICommandHandler<DeleteDocumentCommand> {
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork) {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken) {
        var document = _documentRepository.FindById(DocumentId.Create(request.DocumentId));
        if (document is null)
            return Result.Failure(DocumentErrors.NotFound);
        if (document.Locked)
            return Result.Failure(DocumentErrors.IsLocked);
        _documentRepository.Remove(document);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
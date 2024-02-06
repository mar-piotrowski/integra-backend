using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Document.GetAll;

public class GetDocumentsQueryHandler : IQueryHandler<GetDocumentsQuery, DocumentsResponse> {
    private readonly IDocumentRepository _documentRepository;
    private readonly DocumentMapper _documentMapper;

    public GetDocumentsQueryHandler(IDocumentRepository documentRepository, DocumentMapper documentMapper) {
        _documentRepository = documentRepository;
        _documentMapper = documentMapper;
    }

    public async Task<Result<DocumentsResponse>>
        Handle(GetDocumentsQuery request, CancellationToken cancellationToken) {
        var documents = _documentRepository.FindAll().ToList();
        return !documents.Any()
            ? Result.Failure<DocumentsResponse>(DocumentErrors.NotFoundMany)
            : Result.Success(new DocumentsResponse(_documentMapper.MapToDtos(documents)));
    }
}
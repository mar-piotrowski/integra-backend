using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document.Get;

public class GetDocumentQueryHandler : IQueryHandler<GetDocumentQuery, DocumentDto> {
    private readonly IDocumentRepository _documentRepository;
    private readonly DocumentMapper _documentMapper;

    public GetDocumentQueryHandler(IDocumentRepository documentRepository, DocumentMapper documentMapper) {
        _documentRepository = documentRepository;
        _documentMapper = documentMapper;
    }

    public async Task<Result<DocumentDto>> Handle(GetDocumentQuery request, CancellationToken cancellationToken) {
        var document = _documentRepository.FindById(DocumentId.Create(request.DocumentId));
        return document is null
            ? Result.Failure<DocumentDto>(DocumentErrors.NotFound)
            : Result.Success(_documentMapper.MapToDto(document));
    }
}
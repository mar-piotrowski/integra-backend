using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class DocumentMapper {
    private readonly StockMapper _stockMapper;
    private readonly ContractorMapper _contractorMapper;
    private readonly ArticleMapper _articleMapper;

    public DocumentMapper(StockMapper stockMapper, ContractorMapper contractorMapper, ArticleMapper articleMapper) {
        _stockMapper = stockMapper;
        _contractorMapper = contractorMapper;
        _articleMapper = articleMapper;
    }

    public DocumentDto MapToDto(Document document) {
        return new DocumentDto(
            document.Id.Value,
            document.Type,
            document.Number,
            document.IssueDate,
            document.ReceptionDate,
            document.PaymentDate,
            document.Discount,
            document.TotalAmountWithTax,
            document.TotalAmountWithoutTax,
            document.Description,
            document.Locked,
            _articleMapper.MapToDocumentArticleDtos(document.Articles),
            document.Contractor is not null ? _contractorMapper.MapToDto(document.Contractor) : null,
            document.SourceStock is not null ? _stockMapper.MapToDto(document.SourceStock) : null,
            document.TargetStock is not null ? _stockMapper.MapToDto(document.TargetStock) : null
        );
    }

    public IEnumerable<DocumentDto> MapToDtos(IEnumerable<Document> documents) => documents.Select(MapToDto);
}
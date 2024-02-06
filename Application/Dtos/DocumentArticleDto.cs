namespace Application.Dtos;

public record DocumentArticleDto (
    int Id,
    string Name,
    string Code,
    string? Gtin,
    string MeasureUnit,
    string? Pkwiu,
    decimal SellPriceWithoutTax,
    decimal SellPriceWithTax,
    decimal Tax,
    decimal Amount,
    string? Description
);
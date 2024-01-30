namespace Application.Dtos;

public record ArticleDto(
    int Id,
    string Name,
    string Code,
    string? Gtin,
    string MeasureUnit,
    string? Pkwiu,
    decimal BuyPriceWithoutTax,
    decimal BuyPriceWithTax,
    decimal SellPriceWithoutTax,
    decimal SellPriceWithTax,
    decimal Tax,
    decimal Amount,
    string? Description
);
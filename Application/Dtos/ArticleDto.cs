namespace Application.Dtos;

public record ArticleDto(
    int Id,
    string Name,
    string Code,
    string Gtin,
    string MeasureUnit,
    string Pkwiu,
    decimal BuyPriceWithoutTax,
    decimal BuyPriceWithTax,
    decimal SellPriceWithoutTax,
    decimal SellPriceWithTax,
    int TaxId,
    string Description
);
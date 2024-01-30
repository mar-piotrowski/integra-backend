namespace Application.Dtos; 

public record UpdateArticleRequest (
    int ArticleId,
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
    string? Description
);